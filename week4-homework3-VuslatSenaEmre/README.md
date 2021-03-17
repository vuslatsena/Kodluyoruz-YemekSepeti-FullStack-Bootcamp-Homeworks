# week4-homework-VuslatSena
 
+ HTask1: Singleton -  Transaction - Scoped  kavramlarını açıkça anlaşıldığı bir örnek yapılacak. 

Singleton: Bir programın yaşam süresince belirli bir nesneden sadece bir örneğinin(instance) olmasını garantiler. Aynı zamanda bu nesneye global düzeyde mutlaka erişimi hedefler.

Transaction:Daha küçük parçalara ayrılamayan işlem demektir. Özellike bir grup işlemin arka arkaya gerçekleşiyor olmasına rağmen, seri işlemler halinde ele alınması gerektiğinde kullanılır.

Scoped:Her request için tek bir instance yaratılmasını sağlayan lifetime seçeneğidir. Request Cycle'ı tamamlanana kadar gerçekleşen servis çağrılarında daha önce oluşturulan instance gönderilir ardından yeni bir request başladığında farklı bir instance oluşturulur.

status: done.

+ HTask2: MiddleWare Loglama yapan bir projemiz olacak.

Request ve response’lar ayrı ayrı loglanacak.

Log içeriklerini sizin belirlemenizi istiyorum.(Bu log ne zaman gelmiş vb sorularına cevap olması gerekiyor. )
  Dosyalar içerisinden arama yaparken; 
  
		Request.txt ‘den seçtiğim bir request’in response’unu  Response.txt içerisinde kolaylıkla bulabilmeliyim
		Request     : Request.txt
		Response    :  Response.txt

customer'dan id ve name aldık.
status: done

+ HTask3: CleanCode dersinde konuştuğumuz tüm maddelerin örneklerini Console Application üzerinde örneklenecek.

	Konu içeriklerine aşağıdaki linklerden ulaşabilirsiniz. Örnekleriniz aynı olmasın.
	https://bilisim.io/2020/04/20/clean-code-principles/
	https://bilisim.io/2020/04/25/clean-code-method-principles/
	
	Boolean Expressions
	
	Be Positive
	
	Ternary If
	
	Strongly Type
	
status: done.


+ HTask4: 2 adet controller  Totalde minimum 4 action olacak şekilde ( fazlası da olabilir )bir senaryo oluşturup proje oluşturulacak.
	    Projenize  Swagger eklenecek.
            
+ HTask5: Min 2 controller totalde minimum 4 action olacak şekilde ( fazlası da olabilir ) bir senaryo oluşturulacak.
	    Projede 3. Hafta yaptığımız Generic Repository Pattern uygulanacak.
	    
            Select - Insert - Update - Delete işlemleri yapılması gerekiyor.
	    
	   The Movie Store folder 
status: done.

+ HTask6: Db üzerinden ,applicationSetting veya txt herhangi birini tercih edebilirsiniz.

	     IP adresi  ve ulaşabileceği controller şeklinde WhiteList oluşturulacak.
			192.168.1.1
				 HomeController 
				 CustomerController
			 192.168.1.2
				  PersonController

	      Request geldiğinde whiteList’e uymayanlar handle edilecek message ve status eklenip geriye dönülebilir.


status: done.

+ HTask7: Derste işlediğimiz Versionlama tekrar edilecek. QueryString ve  header üzerinden version bilgisini okuyan versiyonları yapılacak. 
      Versiyonlara göre methodlara erişim vs olması gerekiyor.
      
status: done

+ HTask8: Bu haftaki projemize temize çekilip yeniden yazılacak.  (Test için yaptığımız controller vs kaldırabilirsiniz.)
      JWT ‘de Refresh Token eklenecek.
      
status: proje temize çekildi HotelsAPI olarak yer alıyor.

JWT'de Refresh Token eksik.


+ HTask9: X bir iş yapan “Worker Service” oluşturulacak.
      Ayrı bir proje olabilir veya mevcut bir projeye dahil olabilir. 
      Günlük hayatınızda işinize yarayacak bir şey de olabilir ( Örneğin belirli bir lokasyonda son 3 aydır hiç erişmediğiniz klasörlerin listesini veren bir servis )
      
      
status: done
