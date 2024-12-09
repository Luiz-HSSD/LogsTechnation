# LogsTechnation
executar o arquivo sql em ./SQL/lbancodedados.sql

o cadastro de logs é feito por upload de arquivos
curl --location 'https://localhost:44395/api/LogMinhaCdn?retorno=path' \
--form 'file=@"/C:/Users/lhenr/OneDrive/english/input-01.txt"'

curl --location 'https://localhost:44395/api/LogAgora?retorno=path' \
--form 'file=@"/C:/Users/lhenr/OneDrive/english/input-01.txt"'