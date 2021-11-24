using Microsoft.Extensions.Configuration;
using MyBlog.Services.MailServices;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IServiceCollectionExtensions
    {
        //Extension for IServiceCollection to register SendMailService to DI
        public static void AddSendMailService (this IServiceCollection services, IConfiguration iconfiguration)
        {
            //Read mailsetting information from appsetting.json
            var mailsetting = iconfiguration.GetSection("MailSettings"); 

            services.AddOptions()                                   //Enable Options to configure service
                .Configure<MailSettings>(mailsetting)            //Configure SendMailService
                .AddSingleton<IEmailSender, SendMailService>();     //Add SendMailService to DI
        }
    }
}
