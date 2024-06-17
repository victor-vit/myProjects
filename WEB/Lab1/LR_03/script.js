
var colors =["red","orange","yellow","chartreuse","green","cyan","skyblue","blue","purple","magenta"];
var i = 0;
var timer = setInterval(My_Colors, 50);


// Функция движения кругов
function My_Circles() {

	var rng = document.getElementById('range');
	var circle1 = document.getElementById('circle1');
	var circle2 = document.getElementById('circle2');
	var circle3 = document.getElementById('circle3');
	var circle4 = document.getElementById('circle4');
	var circle5 = document.getElementById('circle5');
	var circle6 = document.getElementById('circle6');
	var circle7 = document.getElementById('circle7');
	var circle8 = document.getElementById('circle8');
	var circle9 = document.getElementById('circle9');
	var circle10 = document.getElementById('circle10');

	clearInterval(timer);
	timer = setInterval(My_Colors, Math.round((0.5 / rng.value)*1000));


	circle1.style.animationDuration = 0.5 / rng.value + 's';
	circle2.style.animationDuration = 0.5 / rng.value + 's';
	circle3.style.animationDuration = 0.5 / rng.value + 's';
    circle4.style.animationDuration = 0.5 / rng.value + 's';
    circle5.style.animationDuration = 0.5 / rng.value + 's';
    circle6.style.animationDuration = 0.5 / rng.value + 's';
    circle7.style.animationDuration = 0.5 / rng.value + 's';
    circle8.style.animationDuration = 0.5 / rng.value + 's';
    circle9.style.animationDuration = 0.5 / rng.value + 's';
    circle10.style.animationDuration = 0.5 / rng.value + 's';
}

// Функция переливания цвета
function My_Colors() {

	var circle1 = document.getElementById('circle1');
	var circle2 = document.getElementById('circle2');
	var circle3 = document.getElementById('circle3');
	var circle4 = document.getElementById('circle4');
	var circle5 = document.getElementById('circle5');
	var circle6 = document.getElementById('circle6');
	var circle7 = document.getElementById('circle7');
	var circle8 = document.getElementById('circle8');
	var circle9 = document.getElementById('circle9');
	var circle10 = document.getElementById('circle10');

	circle1.style.color = colors[i % 10];
	circle2.style.color = colors[(i+1) % 10];
	circle3.style.color = colors[(i+2) % 10];
	circle4.style.color = colors[(i+3) % 10];
	circle5.style.color = colors[(i+4) % 10];
	circle6.style.color = colors[(i+5) % 10];
	circle7.style.color = colors[(i+6) % 10];
	circle8.style.color = colors[(i+7) % 10];
	circle9.style.color = colors[(i+8) % 10];
	circle10.style.color = colors[(i+9) % 10];

	if (i == 10) {
		i = 0;
	}

	i++;

}
