# Haber Projesi
### Web Uygulaması 
#### .NET CORE 7, N-Tier Layer ile geliştirilmiştir. Haberlerin listelendiği Anasayfa ve Detal sayfası olmak üzere iki sayfadan oluşmaktadır. API üzerinden json formatında alınan veriler listelenmekte, kategorilerine ve giriş yapılan değere göre filtreleme işlemi yapılarak listeleme işlemi yapılmaktadır. 

### Projenin çıktısı Anasayfa


https://github.com/SerifeGokdas1/NewsProject/assets/117410162/3e877b2e-afb3-47b2-b86e-99232d894254


### Projenin çıktısı Detay
Uploading Haberler - Detail NewsProject.mp4…

## Projenin kodları

#### Proje .net core 7 ile geliştirilmiştir ve katmanlı mimari kullanılmıştır. 

![image](https://github.com/SerifeGokdas1/NewsProject/assets/117410162/9efb622c-5d6c-464b-8d6e-9b2d2ba08ec0)

#### NewsProject katmanında arayüz işlemleri bulunmaktadır. NewsProject.Business katmanında CRUD işlemleri yapılmıştır. NewsProject.Model katmanında listeleme yapılacak JSON verileri için modeller oluşturulmuştur.

#### Model katmanında, detay.json ve anasayfa.json APIlerinden veri çekme işlemi yapabilmek için detay ve haberler için model sınıfları oluşturulmuştur. 
![image](https://github.com/SerifeGokdas1/NewsProject/assets/117410162/2141a7b5-5b58-4f88-8608-c49cab76d20d)

#### Business katmanında Service klasörü oluşturularak API bağlantısı oluşturularak GetStringAsync metoduyla veriler çekilmiştir. 
![image](https://github.com/SerifeGokdas1/NewsProject/assets/117410162/b4ec05a9-823c-4947-9ce7-3036f9199af1)

#### Proje katmanında ilk olarak Program.cs içerisine Business katmanında oluşturduğum serviceler eklenmiştir.
![image](https://github.com/SerifeGokdas1/NewsProject/assets/117410162/d04bee17-45cf-4da4-9253-bd6479c4a1a9)

#### Daha sonra proje katmanında haberler ve detay için Controller oluşturulmuştur. Controllerlarda API bağlantı işlemi ve listeleme metodunun kullanımı için Businessda oluşturulan Service sınıfları çağırılmıştır.
![image](https://github.com/SerifeGokdas1/NewsProject/assets/117410162/83dd6385-6627-4b82-8fb8-c7f305751bb5)

#### Anasayfada sadece listeleme işlemi yapacağım için sadece Index ActionResultu oluşturulmuştur. Anasayfa içerisindeki get metoduyla alınan haberlerin sayısına göre aşağıda sayfa sayısı bulunması ve her sayfada 5 haber listelenmesi için işlemler yapılmıştır. Bunun yanında anasayfada üst kısımda kategoriye göre listeleme yapılacağı ve anahtar kelime girişi yapılarak haberler içerisinde listeleme için işlemler de yapılmıştır. 
![image](https://github.com/SerifeGokdas1/NewsProject/assets/117410162/50f359e7-af7b-40ae-b6eb-42dfe8234acc)

#### Controllerdaki Indexse AddView ile boş razor sayfası oluşturulmuştur. Daha sonra bu sayfa içerisine haber listeleme, categori ve anahtar kelimeye göre haber listeleme için basit hmtl kodları oluşturulmuştur.

![image](https://github.com/SerifeGokdas1/NewsProject/assets/117410162/6f8a1f8f-4b1e-4c82-ae67-45835bd1c2a4)

#### Detay Controller sınıfı ve html sayfası yukarıda anlattığım işlemler gibi oluşturulmuştur sadece detay sayfasında filtreleme işlemi yapılmamıştır. 
![image](https://github.com/SerifeGokdas1/NewsProject/assets/117410162/82e6c67d-8479-444b-b7b0-31fe2a0da9d1)

![image](https://github.com/SerifeGokdas1/NewsProject/assets/117410162/1ca16a06-d889-4ba2-bde5-12ee4d0e7005)








