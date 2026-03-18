# ✈️ Savaş Oyunu 

📥 [Savaş Oyunu v0.2.0 Alpha'yı İndir (.exe)](https://github.com/ahmetfarukikiz/SavasOyunu/releases/download/v0.2.0-alpha/UcakOyunuKurulum.exe)

## 📝 Proje Hakkında
Bilgisayar Mühendisliği öğrenciliğimin 1.senesinde [Sinan İlyas](https://github.com/sinanilyas) hocamın "[C# ile NDP Örneği] Savaş Oyunu" youtube videosundaki örneğin üzerine eklemeler yaparak geliştirdiğim oyun projem.

Videodaki temel yapının üzerine şunları ekleyerek projeyi özgünleştirdim:
*  **2 Boyutlu Hareket:** Oyundaki uçaksavar artık yukarı aşağı da hareket edebilir.
*  **Aktif Düşmanlar:** Oyuncuyu aktif olarak takip edip ateş edebilen uzay gemileri eklendi.
*  **Yeni Nesneler:** Can ve Yıldız gibi özellik kazandıran nesneler eklendi.
*  **Animasyonlar:** Vurulan uçaklar için patlama efekti ve mermi animasyonu eklendi.

## 🎯 Oyun Konsepti
* Oyundaki amacımız bir savaş jeti (uçaksavar) olarak hava sahasının karşı tarafına geçmeye çalışan pasif (büyük, küçük uçaklar) ve aktif (Uzay gemisi) düşmanları mermilerimizle 
etkisiz hale getirmek. Karşı tarafa ulaşan her düşman ve bize isabet eden her düşman mermisi canımızın gitmesine sebep olmaktadır. Oyun boyunca düşman
uçakların yanında bize güç sağlayan çeşitli nesneler de karşımıza çıkmaktadır. (can, yıldız) 


## 🏗️ Mimari ve Teknolojiler
Projedeki mimariyi **Nesne Yönelimli Programlama (OOP)** üzerine inşa ettim:


### Kullanılan Teknolojiler:
<div>
  <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white" />
  <img src="https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" />
  <img src="https://img.shields.io/badge/Windows_Forms-0078D6?style=for-the-badge&logo=windows&logoColor=white" />
</div>

### Sınıf Yapısı:
Kod tekrarını önlemek ve yönetilebilirliği artırmak için şu miras yapısı kurulmuştur:

* **Cisim (Base Class):** Oyundaki tüm nesnelerin atasıdır.
    * **Ucak (Abstract):** Düşman cisimler bu sınıftan türetilir.
    * **Mermi (Abstract):** Tüm mermilerin temel sınıfıdır.
        * `DusmanMermi`
        * `UcakSavarMermi`
    * **Interface Kullanımı:** Sınıfların yetenekleri (IHareketEden, IOyun) interface'ler ile ayrıştırılmıştır.
<div align="center">
  <img src="https://github.com/user-attachments/assets/1b343a2a-bbdf-4b14-bb14-71223c8106cf" width="80%" alt="Class Diagram" />
</div>

---

## 🎓 Projenin Bana Kattıkları
* **Git ve commit kullanarak projeleri adım adım geliştirme konusunda deneyim edindim.**
* **Savas.Desktop ve Savas.Library ayırarak bir solution içerisinde 2 proje kullandım. Bu sayede ileride bu classları farklı bir projede kullanmak istersem WinForm'a bağlı kalmamış olacağım.**
* **OOP ve Interface kullanımım sayesinde yönetilebilir ve geliştirilebilir bir proje geliştirmiş oldum.**
* **C# Events ve Özelleştirilmiş EventArgs kullanımını öğrendim ve pekiştirdim.**

## 📷 Oyun İçi Ekran Görüntüleri

<div align="center">
  <img src="https://github.com/ahmetfarukikiz/SavasOyunu/blob/master/gorseller/oyun1.png?raw=true" alt="Oyun Görüntüsü 1" width="600">
  <br><br>
  
  <img src="https://github.com/ahmetfarukikiz/SavasOyunu/blob/master/gorseller/oyun2.png?raw=true" alt="Oyun Görüntüsü 2" width="600">
  <br><br>

  <img src="https://github.com/ahmetfarukikiz/SavasOyunu/blob/master/gorseller/oyun3.png?raw=true" alt="Oyun Görüntüsü 3" width="600">
  <br><br>

  <img src="https://github.com/ahmetfarukikiz/SavasOyunu/blob/master/gorseller/oyun5.png?raw=true" alt="Oyun Görüntüsü 5" width="600">
  <br><br>

  <img src="https://github.com/ahmetfarukikiz/SavasOyunu/blob/master/gorseller/oyun4.png?raw=true" alt="Oyun Görüntüsü 4" width="600">

</div>

<br>

---

<div align="center">
  Bu proje eğitim amaçlı geliştirilmiştir. 🎓
</div>

## Kaynak
Projeyi aldığım video serisi: https://www.youtube.com/watch?v=QE7cc1X3Aks&list=PLp2H2NvRDf2TmxPjxkDfv0kMBLE9gp4vk 
