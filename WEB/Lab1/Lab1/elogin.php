<?php

// переменные для логина и пароль пользователя
$login = isset($_POST["login"]) ? $_POST["login"] : "";
$password = isset($_POST["passwordD"]) ? $_POST["passwordD"] : "";

$file['login'] = 'login.html';  // переменная для файла с исходной формой
$file['lab2'] = 'lab2.html';    // переменная для файла с формой п.7

// подключение к БД
$mysqli = new mysqli("localhost", "root", "qwerty", "login");

// проверка соединения 
if (mysqli_connect_errno()) {
    printf("Подключение не удалось: %s\n", mysqli_connect_error());
    exit();
}


$action = $_POST['entrance'];
if ($action == 'Войти'){
    // составление запроса на проверку пользователя по логину
    $res = $mysqli->query("SELECT id FROM users WHERE login='$login';");
    $row = $res->fetch_assoc();

    if (!empty($row['id'])) {   
        $res = $mysqli->query("SELECT id FROM users WHERE password='$password';");
        $row = $res->fetch_assoc();
        if (!empty($row['id'])) {  
            $content = file_get_contents($file['lab2']);
            echo ($content);
        }
        else {
            echo 'Введен неверный пароль.';
            $content = file_get_contents($file['login']);
            echo ($content);
        }
    }
    else{
        echo 'Пользователь с таким логином не найден. Необходима регистрация.';
        $content = file_get_contents($file['login']);
        echo ($content);
    }
}

else {
    // составление запроса на проверку пользователя по логину
    $res = $mysqli->query("SELECT id FROM users WHERE login='$login';");
    $row = $res->fetch_assoc();
 

    if (!empty($row['id'])) {   
       echo 'Пользователь с таким логином уже существует. Придумайте другой логин для регистрации.';
       $content = file_get_contents($file['login']);
       echo ($content);
    }
    else {
        $res = $mysqli->query("INSERT into users (login, password) values ('$login', '$password');");
        echo 'Здравствуйте, Вы успешно зарегистрированы!';
        $content = file_get_contents($file['lab2']);
        echo ($content);
    }       
}
