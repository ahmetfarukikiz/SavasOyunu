using System.Reflection;

namespace Savas.Library.Helpers
{
    public static class ResimYukleyici
    {
        public static Image GorselGetir(string resimAdi)
        {
            var assembly = Assembly.GetExecutingAssembly();

            string tamAd = $"Savas.Library.Resimler.{resimAdi}";

            using Stream stream = assembly.GetManifestResourceStream(tamAd);
            if (stream == null)
                throw new FileNotFoundException($"Gömülü kaynak bulunamadı: {tamAd}");

            return Image.FromStream(stream);
        }
    }
}
