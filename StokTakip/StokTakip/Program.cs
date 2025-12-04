using StokTakip.Data;
using StokTakip.Services;
using StokTakip.StokTakip.Data;

namespace StokTakip
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            // ?? Uygulama açýlýrken Yetkili þifresini kontrol et (Form açýlmadan önce)
            using (var context = new StokTakipContext())
            {
                var services = new PersonelServices(new PersonelRepository(context));

                if (string.IsNullOrEmpty(services.GetYetkiliSifreHash()))
                {
                    var yetkiliForm = new YetkiliSifreForm();
                    yetkiliForm.ShowDialog();
                }
            }

            Application.Run(new PersonelGirisi());
        }
    }
}