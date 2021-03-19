using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Week5.Models;

namespace Week5.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class DapperSampleControl : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public DapperSampleController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void checkConnection(IDbConnection db)
        {
            if (db.State != ConnectionState.Open)
            {
                db.Open();
            }
        }
        public IActionResult DapperSelect()
        {
            /*Dapper Nedir?
             * Dapper, Stack overflow ekibi tarafından LightWeight(Arka tarafta herhangi bir mapping işlemi veya konfigürasyonu yapmaz) olarak geliştirilmiş 
             * Github ta open source yayınlanan bir ORM( Object Relationship Mapper) aracıdır.
             * 
             * Öncelikle oluşturduğum databasedeki table.Person tablosundaki bütün verileri listelemek istiyorum.
             * Bunun için bir SQL komutu oluşturdum.
             * Query methodu ile de çalıştırılabilir hale getirdim.
             * Tabloda yer alan ID,FirstName,LastName verilerini çekmiş oldum.
             *  Sql komutunun profilerdaki hali : select * from [Table].[Person]
             */
            IEnumerable<Person> persons;
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                checkConnection(db);

                string sql = "select * from [Person].[Person]";

                persons = db.Query<Person>(sql);
            }
            return Ok(persons);
        }

        public IActionResult DapperInsert()
        {
            /*
             * Insert into kullanarak SQL ekleme işlemlerini gerçekleştirecek bir komut yazdım.
                Databaseimde test için dbo.TestPerson adında bir tablo oluşturdum.
             */

            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                checkConnection(db);

                string sql = @"insert into dbo.TestPerson (Name, Surname) values (@Name, @Surname);";

                TestPerson testData = new TestPerson { Name = "Tunahan", Surname = "Aydinoglu" };
                var affected = db.Execute(sql, testData);
            }
            return Ok();
        }

        public IActionResult DapperUpdate()
        {
            /*
             * DapperUpdate: Yazdığımız SQL komutu ile udpate(güncelleme) işlemini yapmak istiyoruz.
             * Eğer parametresi id ile eşleşiyorsa Name alanını bizim göndermiş olduğumuz name alanıyla güncellemek istiyoruz.
             */
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                checkConnection(db);

                string sql = @"Update dbo.TestPerson Set Name = @Name where Id=@Id ";

                var updatePersons = new[] {
                    new {Id=1 , Name="Kerem"},
                    new {Id=2 , Name="Tun"}
                };

                var affected = db.Execute(sql, updatePersons);
            }

            return Ok();
        }

        public IActionResult DapperDelete()
        {
            /*
             * Burada Delete işleminin SQL komutunu yazdık. 
             * Dapperın execute methoduna gönderdik.
             * Parametre olarak ID için bir obje gönderiyoru<.
         */
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                checkConnection(db);

                string sql = @"Delete from dbo.TestPerson where Id=@Id";
                var affected = db.Execute(sql,
                    new { Id = 3 }
                );
            }
            return Ok();
        }

        public IActionResult DapperDeleteInQuery()
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                checkConnection(db);

                string sql = @"Delete from dbo.TestPerson where Id=@Id";
                var data = db.Query(sql,
                    new { Id = 4 }
                );
            }

            return Ok();
        }

        public IActionResult DapperSP()
        {

            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                checkConnection(db);

                string sql = "dbo.SelectTestPersons";
                db.Execute(sql, null, commandType: CommandType.StoredProcedure);
            }
            return Ok();
        }

        public IActionResult DapperTransaction()
        { 

            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                checkConnection(db);

                using (var transaction = db.BeginTransaction())
                {

                    string sql = @"insert into dbo.TestPerson (Name,Surname) values (@Name,@Surname);";

                    TestPerson testPerson = new TestPerson { Name = "Deneme name", Surname = "Surname" };
                    db.Execute(sql, testPerson, transaction);


                    CanceledReason scrapReason = new CanceledReason { Name = "Scrap added", ModifiedDate = DateTime.Now };
                    sql = @"Insert into [Production].[ScrapReason] (Name, ModifiedDate) values (@Name, @ModifiedDate);";
                    db.Execute(sql, scrapReason, transaction);

                    transaction.Commit();
                }
            }

            return Ok();
        }
        public IActionResult DapperResultMapping()
        {
            //Dapper QueryFirstOrDefault yapısı ile dönen sonuçların ilkini aldık.
            using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                checkConnection(db);
                string sql = "select AddressLine1,City,PostalCode from [Person].[Address]";

                var data = db.QueryFirstOrDefault(sql);

                return Ok(data);
            }

        }
        public IActionResult DapperOneToOne()
        {
            /*
             * 2 tabloyu inner join ile birbirine eşitledik.
             */
            using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                checkConnection(db);
                string sql = "select * from [Purchasing].[PurchaseOrderHeader] as Pur Inner Join [HumanResources].[Employee] as Emp ON Pur.EmployeeID = Emp.BusinessEntityID;";

                var data = db.Query<OrderName, Employee, OrderName>(
                        sql,
                        (order, employee) =>
                        {
                            order.Employee = employee;
                            return order;
                        },
                        splitOn: "EmployeeID"
                        ).Distinct().ToList();
                return Ok(data);
            }
        }
        public IActionResult DapperOneToMany()
        {
            /*O2M iliski kurabilmek icin inner join sql sorgusu yazdim.
             */
            using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                checkConnection(db);
                string sql = "select * from [Production].[ProductCategory] as Cat Inner Join [Production].[ProductSubcategory] as Sub ON Cat.ProductCategoryID = Sub.ProductCategoryID;";

                var categoryDictionary = new Dictionary<int, ProductsCategory>();

                var data = db.Query<ProductsCategory,ProductsSubCategory,ProductsCategory>(sql,
                    (category, subCategory) =>
                    {
                        ProductCategory categoryData;
                        if (!categoryDictionary.TryGetValue(category.ProductCategoryID, out categoryData))
                        {
                            categoryData = category;
                            categoryData.ProductSubcategories = new List<ProductSubcategory>();
                            categoryDictionary.Add(categoryData.ProductCategoryID, categoryData);
                        }
                        categoryData.ProductSubcategories.Add(subCategory);
                        return categoryData;
                    },
                    splitOn: "ProductSubcategoryID"
                ).Distinct().ToList();

                return Ok(data);
            }
        }
        public IActionResult DapperMultipleQueryMapping()
        {
            //Multiple query methodu inner join islemleri gibi islemlerde kullanabilecegimiz bir method .
               
             using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                checkConnection(db);

                string sql = @"select * from [Production].[Product] where ProductId = @ProductID; Select * from [Production].[ProductCostHistory] where ProductId = @ProductID;";
                Products product;
                using (var multiple = db.QueryMultiple(sql, new { ProductID = 711 }))
                {
                    product = multiple.Read<Products>().First();
                    product.ProductCosts = multiple.Read<ProductsCost>().ToList();
                }
                return Ok(product);
            }

        }


    }
}
