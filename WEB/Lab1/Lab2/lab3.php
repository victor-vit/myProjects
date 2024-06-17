<?php

if (count($_FILES)) {

    $uploaddir = '/var/www/html/lab3/upload/';
    $filename = basename($_FILES['img']['name']);
    $uploadfile = $uploaddir . $filename;

    // данные от пользователя
    $input_text = isset($_POST["inputText"]) ? $_POST["inputText"] : "";    // сообщение
    $font_size = isset($_POST["size"]) ? intval($_POST["size"]) : 14;       // размер шрифта
    $x = isset($_POST["x"]) ? intval($_POST["x"]) : 100;                    // координата x
    $y = isset($_POST["y"]) ? intval($_POST["y"]) : 100;                    // координата y
    $color  = isset($_POST["color"]) ? $_POST["color"] : "";                // цвет текста

    $background = isset($_POST["background"]) ? $_POST["background"] : "";  // заданий фон

    $len = 0.6*$font_size*(strlen($input_text));                            // коэффициент для вывода фона текста

    if (move_uploaded_file($_FILES['img']['tmp_name'], $uploadfile)) {

        $img = "/var/www/html/lab3/upload/$filename";   // файл png
        $font = '/var/www/html/lab3/font.ttf';          // шрифт
        

        $degree = 0;                                    // угол поворота текста в градусах по заданию 0
        $pic = imagecreatefrompng($img);                // создание изображения
        
        // установка цвета
        switch ($color) {

            case 'red': 
                $color = imagecolorallocate($pic, 255, 0, 0); // Функция выделения цвета для текста
                break;
            
            case 'white':
                $color = imagecolorallocate($pic, 255, 255, 255); // Функция выделения цвета для текста
                break;

            case 'black':
                $color = imagecolorallocate($pic, 0, 0, 0); // Функция выделения цвета для текста
                break;
            
            case 'blue':
                $color = imagecolorallocate($pic, 0, 0, 255); // Функция выделения цвета для текста
                break;

            case 'lime':
                $color = imagecolorallocate($pic, 0, 255, 0); // Функция выделения цвета для текста
                break;  
        }

        // установка фона (при необходимости)
        if ($background != 'No'){
            $grey = imagecolorallocate($pic, 128, 128, 128);
            imagefilledrectangle($pic, $x, ($y-$font_size), ($x + $len), $y, $grey);
        }

        // наносим текст
        imagettftext($pic, $font_size, $degree, $x, $y, $color, $font, $input_text); 

        // сохраняем картинку 
        imagepng($pic, "/var/www/html/lab3/upload/ress.png"); 

        // вывод результата
        echo '<img src="upload/ress.png" alt="картинка">';

        // освобождение памяти и закрытие рисунка
        imagedestroy($pic);

    } else {
        echo "Ошибка загрузки файла!\n";
    }
        
}
