# **ApiPortalNoticias**

Essa API fornece acesso a um banco de dados de notícias que permite que os autores publiquem, editem, visualizem e excluam suas próprias notícias.

<br>

## Endpoints


### Noticias
*GET* **/api/noticias**
<br>Retorna todas as notícias.

*GET* **/api/noticias/{id}**
<br>Retorna a notícia com o ID especificado.

*POST* **/api/noticias**
<br>Cria uma nova notícia.

*PUT* **/api/noticias/{id}**
<br>Atualiza a notícia com o ID especificado.

*DELETE* **/api/noticias/{id}**
<br>Exclui a notícia com o ID especificado.

<br>

### Autores
*GET* **/api/autores**
<br>Retorna todos os autores.

*GET* **/api/autores/{id}**
<br>Retorna o autor com o ID especificado.

*POST* **/api/autores**
<br>Cria um novo autor.

*PUT* **/api/autores/{id}**
<br>Atualiza o autor com o ID especificado.

*DELETE* **/api/autores/{id}**
<br>Exclui o autor com o ID especificado.

<br>
 
### Tecnologias Utilizadas
- .NET 6 Web API
- SQLite
- EntityFramework Core
- Identity

<br>

## Autor
Esse projeto foi desenvolvido por Hugo Victor.
