# invitatech
 
### Após fazer o clone do projeto siga estes passos

# Servidor

Api/LoremIpsumLogistica.sln

- Abra a solution e faça um build da solution
- Em seguida, abra o arquivo appsettings.json se for rodar em debug lembre-se de alterar o appsettings.Development.json 
- Faça os ajustes necessários na string de conexão

"ConnectionStrings": {
"DefaultConnection": "Server=<<APONTE PARA SUA BASE>>;Database=<<NOME DO SEU BANCO DE DADOS>>;Trusted_Connection=True;TrustServerCertificate=False;"
}

- Em favor da brevidade, não especifiquei um usuário para o banco de dados, embora isso seja altamente recomendado em um ambiente real;
- No menu superior do Visual Studio 2022 clique em tools -> Nuget Package Manager -> Package Manager Console
- Altere o Default project para o repositório
- Execute o comando Update-Database
- Se tudo correr bem, seu banco estará criado, e as tabelas também;

- Marque o projeto LoremIpsumLogistica.UI.Api como sendo o Startup Project
- Execute o Servidor

Agora, vamos para o Site

#Site

- Navegue até a pasta Site, mais interna no repositório que você clonou
- clique com o botão direito, em seguida em Abrir terminal
- Confira se o caminho no terminal é da da pasta que você estava
- Execute o comando "code ." sem as aspas
- Abra o arquivo src/app/services/cliente.service.ts e ajuste o valor da variavel apiUrl para corresponder a execução da sua api
- Faça o mesmo para src/app/services/endereco.service.ts
- Pressione CTRL + " para abrir o terminal dentro do visual code
- digite "npm i" sem as aspas, para recriar a pasta node_modules
- digite o comando "ng serve" para rodar o site 








