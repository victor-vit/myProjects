<?php

// переменные для хранений текстовых данных
$model = isset($_POST["model"]) ? $_POST["model"] : "";
$count = isset($_POST["count"]) ? $_POST["count"] : "";
$comment = isset($_POST["comment"]) ? $_POST["comment"] : "";
$adress  = isset($_POST["adress"]) ? $_POST["adress"] : "";
$company = isset($_POST["company"]) ? $_POST["company"] : "";
$phone = isset($_POST["phone"]) ? $_POST["phone"] : "";
$email = isset($_POST["email"]) ? $_POST["email"] : "";


// где покупалось оборудование
$buyPlace = isset($_POST["buy"]) ? $_POST["buy"] : "";
if ($buyPlace == 'official'){
    $buyPlace = "в официальном магазине";
}
if ($buyPlace == 'notofficial'){
    $buyPlace = "в неофициальном магазине";
}
if ($buyPlace == 'nodata'){
    $buyPlace = "нет данных";
}


// производство
$country = isset($_POST["country"]) ? $_POST["country"] : "";
if ($country == 'rus'){
    $country = "отечественное";
}
if ($country == 'norus'){
    $country = "импортное";
}


// срочный заказ
$fast = isset($_POST["fast"]) ? $_POST["fast"] : "";
if ($fast == 'on'){
    $fast = 1;          // если заказ срочный, то в БД запишем 1
}
else{
    $fast = 0;          // иначе 0
}

// марка
$marka = isset($_POST["marka"]) ? $_POST["marka"] : "";

// день недели
$day = isset($_POST["day"]) ? $_POST["day"] : "";


// подключение к БД
$mysqli = new mysqli("localhost", "root", "qwerty", "labaratory2");

// проверка соединения 
if (mysqli_connect_errno()) {
    printf("Подключение не удалось: %s\n", mysqli_connect_error());
    exit();
}

// добавление данных в БД
$res = $mysqli->query("INSERT into usersData (modelT, countT, brandT, comment, adressC, nameC, buyPlace, country, phone, email, theDay, fast) 
                        values 
        ('$model', '$count', '$marka', '$comment', '$adress', '$company', '$buyPlace', '$country', '$phone', '$email', '$day', '$fast');");

echo "Данные успешно отправлены!<br>";