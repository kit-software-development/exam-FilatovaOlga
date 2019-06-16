# exam-FilatovaOlga
exam-FilatovaOlga created by GitHub Classroom

Это клиент-серверное приложение для тестирования пользователей.

Для работы приложения необходимо запустить сервер TestsApp.Server. 
Затем можно запускать экземпляры клиента TestsApp.Client. 
!!! Перед запуском клиента необходимо убедиться, что в форме StartForm.cs переменной ipAddressString присвоен ip-адрес компьютера, на котором запущен сервер !!!
Вопросы теста хранятся в базе данных на сервере. Все обращение клиентов к вопросам из базы данных происходит через сервер.

Каждый пользователь может:
1) пройти тест 
Для каждого пользователя вопросы появляются в случайном порядке. Случайная последовательность вопросов генерируется на клиенте. 

2) добавлять новые вопросы в базу данных
Новые вопросы будут доступны всем пользователям, которые начали проходить тест после добавления вопроса.


На сервере через консоль доступны обращения к базе данных.
Список команд:
questions - вывести список вопросов из базы;
delete    - удалить вопрос из базы по id;
exit      - закончить работу сервера.


- TestsApp.Server:
 Весь код содержится в Program.cs файле
 Также на сервере находится файл базы данных Database.mdf

- TestsApp.Client:
 Содержит 3 формы
1) StartForm.cs - стартовая форма с кнопками "Начать тест" и "Добавить новый вопрос в базу"
2) QuestionForm.cs - форма для прохождения теста
3) AddQuestionForm.cs - форма для добавления нового вопроса в базу данных

- TestsApp.Lib
Библиотека, которая обеспечивает взаимодействие между клиентом и сервером и содержит типы сообщений передаваемых между клиентом и сервером. Взаимодействие между клиентом и сервером ведется по UDP.