<a id="readme-top"></a>

# Challenge 2025 - Advanced Business Development with .NET

![Static Badge](https://img.shields.io/badge/build-passing-brightgreen) ![Static Badge](https://img.shields.io/badge/Version-1.0.0-blue)

## 🧑‍🤝‍🧑 Informações dos Contribuintes

| Nome                          | Matrícula | Turma  |
| :---------------------------: | :-------: | :----: |
| Felipe Nogueira Ramon         | RM555335  | 2TDSPH |
| Pedro Henrique Vasco Antonieti| RM556253  | 2TDSPH |

<p align="right"><a href="#readme-top">Voltar ao topo</a></p>

## 🚩 Características

API RESTful desenvolvida em **.NET 8** com **boas práticas REST**, focada no domínio de **gestão de pátio da Mottu**.  
Principais pontos do projeto:  
- **4 entidades principais**: Motos, Filiais, Localizações e Usuários.  
- **Endpoints CRUD completos** com paginação, códigos de status adequados e HATEOAS nos metodos de get id.  
- **Swagger/OpenAPI** configurado com modelos de dados, exemplos de payloads e documentação.  
- Integração com **Entity Framework Core** e **Oracle** para persistência.  
- Estrutura em camadas (Controllers, Services, Repositories, Data).  

<p align="right"><a href="#readme-top">Voltar ao topo</a></p>

## 🛠️ Tecnologias Utilizadas

* ![Static Badge](https://img.shields.io/badge/.NET%208-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
* ![Static Badge](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)  
* ![Static Badge](https://img.shields.io/badge/Entity%20Framework%20Core-512BD4?style=for-the-badge&logo=nuget&logoColor=white)  
* ![Static Badge](https://img.shields.io/badge/Oracle-F80000?style=for-the-badge&logo=oracle&logoColor=white)  
* ![Static Badge](https://img.shields.io/badge/Swagger-85EA2D?style=for-the-badge&logo=swagger&logoColor=black)  

<p align="right"><a href="#readme-top">Voltar ao topo</a></p>

## 💻 Inicializar projeto

### 📝 Pré-requisitos
- **.NET SDK 8.0** instalado  
- **Oracle** (local ou remoto)  

### 🗃️ Instalação
1. Clone o repositório:
   ```sh
   git clone https://github.com/ramonfn/Mottu.Patio.API.git
   ```
2. Acesse a pasta:
   ```sh
   cd Mottu.Patio.API
   ```
3. Restaure os pacotes NuGet:
   ```sh
   dotnet restore
   ```
4. Ajuste a connection string no `appsettings.json` conforme seu ambiente Oracle.  
5. Aplique as migrations (se aplicável):
   ```sh
   dotnet ef database update
   ```
6. Rode o projeto:
   ```
   F5
   ```

<p align="right"><a href="#readme-top">Voltar ao topo</a></p>
