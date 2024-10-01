using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp;
using lovelove.Dbconfig;


public class startup{
    public startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }
    
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRazorPages();
        services.AddSingleton<DbSettings>();
        services.AddHttpContextAccessor();
        services.AddSingleton<IFirebaseClient, FirebaseClient>();
        services.AddSingleton<IFirebaseClient>(provider =>
        {
            var settings = provider.GetRequiredService<DbSettings>(); // classe DbSettings possui uma propriedade chamada Config, que é do tipo IFirebaseConfig. Essa interface é usada para configurar as credenciais e a URL de base para se conectar ao Firebase.
            return new FirebaseClient(settings.Config); 
        });


    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            //Se o ambiente for de desenvolvimento, o aplicativo terá comportamento especial para facilitar a depuração e o desenvolvimento.

            app.UseDeveloperExceptionPage();
        }
        else 
        {   
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }
        app.UseHttpsRedirection();  //Redireciona todas as solicitações HTTP para HTTPS.
        app.UseStaticFiles(); //Habilita o servidor para fornecer arquivos estáticos (como imagens, CSS, JavaScript, etc.) para o cliente.

        app.UseRouting(); 
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}

