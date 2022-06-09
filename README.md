# Example.UnitTests
Xunit Example Project

<br />Referanslar
1.	xunit : xunit metotlarını kullanmamızı sağlar.
2.	xunit.runner.visualstudio : testexplorerda yazdığın testlerin görünmesini sağlar.
3.	Microsoft.Net.test.sdk  : .NET'te test yazmayı sağlayan software deveploment kits 

<br />test metotu isimlendirme standardı
* //[MethodName_StateUnderTest_ExpectedBehavior]
* //addApplication_emptyModel_throwsExpection

<br />AAA Prensibi
* Arrange : değişkenler, classlar, objeler tanımlanır.
* Act : test edilecek metot tetiklenir ve çıktısı alınır.
* Assert : test edilecek metot ile beklenen değer kıyaslanır.

<br />XUnit Assert Metotları
* //Contains  -- DoesNotContain
<br />//Assert.Contains("fatma", "fahriye"); //fail
<br />//Assert.DoesNotContain("fatma", "fahriye"); //success
<br />//var names = new List<string> { "fatma", "fahriye" }; 
<br />//Assert.Contains(names, x => x == "ayşe"); //fail
* //True - False
<br />//Assert.True(5 > 2); //success
<br />//Assert.True(5 < 2); // fail
<br />//Assert.False(5 < 2); //success
<br />//Assert.True("kalem".GetType() == typeof(string)); // success
<br />//Assert.True("kalem".GetType() == typeof(int)); // fail
* //Matches -DoesNotMatch
<br />//var regex = "^dog"; //dog ile başlayan regex rule
<br />//Assert.Matches(regex, "dog tommy"); //success
<br />//Assert.Matches(regex, "tommy dog"); //fail 
<br />//Assert.DoesNotMatch(regex, "tommy dog"); //success 
* //StartsWith - EndsWith
<br />//Assert.StartsWith("bir", "bir gün"); //success
<br />//Assert.EndsWith("masal", "bir masal"); //success
* //Empty - NotEmpty
<br />//Assert.Empty(new List<string>()); // success
<br />//Assert.NotEmpty(new List<string> { "deneme" }); //success
* //InRange - NotInRange
<br />//Assert.InRange(10, 2, 20); //success
<br />//Assert.NotInRange(1, 2, 20); //success
* //Single
<br />//Assert.Single(new List<string> { "fahriye" }); // success
<br />//Assert.Single(new List<string> { "fahriye", "gün" }); // fail
<br />//Assert.Single<int>(new List<int> { 1, 2, 3 }); //fail
* //IsType - IsNotType
<br />//Assert.IsType<string>("asdg"); // success
<br />//Assert.IsType<int>("sfdsf"); //fail
<br />//Assert.IsNotType<int>("sfdsf"); //success
<br />//IsAssignableFrom
<br />//Assert.IsAssignableFrom<IEnumerable<string>>(new List<string>()); // success
<br />//Assert.IsAssignableFrom<object>("fatma"); // success
<br />//beklenen classın generic classtan miras alıp almadığını, bir objenin beklenen objeden türeyip türeyemediğini anlamak için kullanılır.
* //Null - NotNull
<br />//Assert.Null(null); //success
<br />//Assert.NotNull("asdas"); //success
* //Equal - NotEqual
<br />//Assert.Equal(4, Add(2, 2));
<br />//Assert.Equal<int>(4,4);
* //throws
<br />// Exception ex = Assert.Throws<Exception>(()=> testClass.multiple(a, b));
  
<br />XUnit Etiketleri
  * [Fact] // test metodu parametre almıyorsa [Fact] kullanılır.
<br />[Fact]
<br />public void Test1()
<br />{ 
<br />Assert.Equal(4, 2+2);  
<br />}

* [Theory] //parametre alan test metotlarında kullanılır.
* [InlineData(1, 2, 3)] alınacak parametreleri metoda geçirir.
<br />[Theory] 
<br />[InlineData(1, 2, 3)] // success
<br />[InlineData(3, 2, 6)] //fail
<br />public void Test2(int a, int b, int total)
<br />{
<br />    Assert.Equal(total, a + b);
<br />}
  
<br />Mock
 <br />mocklama için aşağıdaki 2 prensipten biri olmalı. tightly couple code içinde unit test yazılamaz.    
* Dependency Injection (DI) //constructor için interfaceler geçmesi. bir design patterndir.
* Absraction 
  
<br />moq framework
 * test dll'ine sağ tıklayıp Manage Nuget Package dediğimizde Moq kütüphanesini test dll imize indiririz.

<br />Dependency Injection (DI)
* Interface oluşturulur. ICalculator .içine hangi metotlar eklenecekse eklenir.
* Service'i oluşturulur. SCalculator ICalculator'dan miras alacak. metotları çekecek
* bir ana class ouşturulur. Calculator burada constructorda ICalculator geçilir.
* test classında var myMock = new Mock<ICalculator>(); diyerek bu interface in taklit edileceğini anlarız.
* var calculator = new Calculator(myMock.Object); diyerek oluşacak calculator nesnesinin taklit edilen interfacele çalışacağını belirtiriz.

<br />moq framework metotları
* Verify()   => myMock.Verify(x=> x.add(a,b), Times.Once);  : add metotunun bir kere çalışıp çalışmadığını doğrular.
* Throws()   => myMock.Setup(x=> x.multiply(a,b)).Throws(new Exception("a 0 olamaz")); : hata fırlatmayı sağlar.
* Callback() => myMock.Setup(x=> x.multiply(It.IsAny<int>(), It.IsAny<int>())).Callback<int,int>((a,b) => actualValue = a*b); :	bir metot üzerinden callback çalıştırmayı sağlar. yani metodun simulasyonunu sağlar.

<br />XUnit ve diğer unit test frameworklerine ait attributes ve assert metotları
 <br />https://xunit.net/docs/comparisons

