using System.Net;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel(options =>
{
    // Sidecar �Ƃ��ăf�v���C�������̂ŁA�|�[�g�ԍ��� 2000 �ɕύX
    options.Listen(IPAddress.Parse("0.0.0.0"), 2000);
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sidecar dotnet Core API V1");
    c.RoutePrefix = string.Empty;
});

// HTTP �Ńz�X�g�������̂� HTTPS ���_�C���N�g�͖�����
//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
