Bootcamp Notları 2: C#’da Temel Kavramlar
Bu yazıda mülakatlar sırasında karşılaşabileceğimiz bazı temel C# kavramları ve örneklerine yer vereceğiz. İsterseniz başlayalım.
Yapı (Struct) Kavramı
Temel olarak Yapılar(Struct) için “Aralarında mantıksal bir ilişki bulunan farklı türden bilgilerin tanımlandığı ve üstlerinde işlemlerin yapıldığı yapı” diyebiliriz.
Aşağıdaki tanımlanmış olan struct içindeki değişkenlere ve metota erişim örneği mevcuttur. Burada struct içindeki değişkenlere değerler atanıyor ve struct içinden metot çağrılarak çalıştırılıyor.


Enum (Enumaration)
Bu yapı yazılım dilinde enum, enumaration ya da enum sabitleri olarak adlandırılır. Değişkenlerin alabileceği değerlerin sabit (belli) olduğu durumlarda programı daha okunabilir hale getirmek için kullanılır. Programda birçok değişkene tek tek sayısal değer vermek yerine “enum” kullanılabilir. Özet olarak “enum” yapısı sayıları anlamlı şekilde isimlendirerek kullanabilmeye izin verir.

Enum içerisindeki elemanlar 0 numarasından başlar.
Mesela günler üzerine olan örneğimizi şu şekilde çağıralım;

Form uygulamasını derlememiz sonucu gün sayısını girdiğimiz zaman 3.indekstekini bize gösterecektir.

Indexer
Bir sınıfa ait nesneleri sanki bir array’in bileşenleri gibi indeksler. Sınıfa ait ögelerin ne olduğu indexer için önemli değildir. O yalnızca yaratılan nesnelere index koyar. Sınıfa ait property’leri tanımlamaya benzer.
Indexer private, public, protected veya internal erişim belirteçleriyle nitelenebilir.

Bu programı çözümleyecek olursak indexerın nasıl çalıştığını anlayabiliz. IndeksYap sınıfındaki “private string[] metin = new string[5];” deyimi string türünden metin adlı, 5 bileşenli private nitelemeli bir array bildirmektedir.
Ardından gelen this pointeri ile yaratılan arrayi işaret eder. get/set erişimcileri arrain bileşenlerine değer atar ve atanan değeri okur.
NesneYap sınıfı içerisindeki Main() metodu “IndeksYap obj = new IndeksYap();” deyimiyle IndeksYap sınfına ait obj adlu bir nesne yaratır. Bu nesnenin string tipinden, 5 bileşenli bir array olduğunu biliyoruz. Main() metodunun sonraki kodları arrayin bileşenerine değerler atıyor sonra o değerleri for döngüsü ile konsola yazdırıyor.

ReadOnly Variables
Readonly tanımlı değişkeni salt okunur moduna getirmektedir. Yani readonly olarak tanımlanan bir değişken sadece okunabilmektedir.
Setleme işlemi değişkenin oluşturulduğu anda ya da oluşturulan sınıfın constructor metodu içerisinde yapılmaktadır. Çalışma zamanında sadece constructor içerisinde değer ataması yapılabilmektedir. Aksi halde salt okunur bir alana değer atanamaz uyarısı vermektedir.
Readonly tanımını burada görüldüğü üzere “public readonly string Isim;” şeklinde değer ataması yapmadan tanımlayabiliriz ya da aşağıda yer alan örnekte olduğu gibi buna bir değer atayarak da yapabiliriz.

Partial class
Büyük projelerde oluşturduğumuz class’ lar zamanla okunması zor hale gelebilecek uzunlukta kod satırları ile dolabilmektedir.
Partial class yapısı bize bir class’ ı birden fazla class olarak bölmemize, constructor, değişken, property, metodları gibi düzenli bir şekilde ayrı ayrı oluşturmamızı sağlamaktadır.
Fiziksel olarak birden fazla parça ile oluşan partial class’ lar, çalışma zamanında tek bir class olarak bütün elemanları içerisinde barındırmaktadır.
Partial class ile fiziksel olarak parça class’ların birleşmesi için class isimlerinin aynı olması gerekmektedir.
Örneğin elimizde Ogrenci.cs class’ı olsun

Bir de OgrenciMethod.cs classı olsun

Program.cs’de bu şekilde olsun

Programı derleme sırasında partial class’ın çalışma mantığı bütün parçalı sınıfları alıp ortak işlevi yerine getirmektir.

Bu örnekte beklediğimiz çıktı kaydın başarılı bir şekilde gerçekleştirilmesidir.

Görüldüğü üzere program tüm class’lardaki methodları, bilgileri alıp çalışma zamanında ortak bir şekilde derleyerek console ekranında sonucu vermiştir.
Okuduğunuz için teşekkürler, bol bol kod yazdığınız bir gün olsun :D
Kaynakça:
C# Struct Kullanımı ve Struct Örnekleri
C#’da Yapılar (Structs) yazımızda Struct’ın ne olduğundan avantaj ve dezavantajlarından bahsetmiştik. Bu yazımızda…
www.bilisimogretmeni.com

https://www.fibiler.com/Divisions/Ehil/Mecmua/Magazines/Articles/txt/html/article_Indexer.html
http://kodlasana.com/programlama/c-sharp/c-dilinde-partial-class-kullanimi.html