// комментарий к коду

// к сожалению, я смог реализовать только построение графика при нажатии кнопки обновить
// и график рисуется сразу, а не плавно, как Вы говорили в подсказке "как бы вы строили график произвольной функции на бумаге"


console.log(eval("var y = x => 0")); 

let scale = 20;
let step = 1;
let cnvs = document.getElementById("canvas");
let ctx = cnvs.getContext('2d');
ctx.lineWidth = 0.25; // толщина линий разметки

// =========================================================================
// сделаем фрагмент клеточной бумаги,
// здесь будет отображаться построенный график
// вериткальные линии
for (var i = step*scale; i < cnvs.width; i += step*scale) { 
  polyline('#7a7979', [[i, 0], [i, cnvs.height]]);
}

// горизонтальные линии
for (var i = step*scale; i < cnvs.height; i += step*scale) { 
  polyline('#7a7979', [[0, i], [cnvs.width, i]]);
}
// =========================================================================

// =========================================================================
// блок построения графика
    ctx.lineWidth = 2;
    let pts = [];
    for(let x = -cnvs.width/2; x<cnvs.width/2; x+=5) {
        pts.push([cnvs.width/2+x, cnvs.height/2 - y(x/scale)*scale]);
    }
    polyline('blue', pts);

// =========================================================================

// =========================================================================
// построим оси
// ось X 
polyline('black', [[0, cnvs.height / 2], [cnvs.width, cnvs.height / 2]]);

// ось Y
polyline('black', [[cnvs.width / 2, 0], [cnvs.width / 2, cnvs.height]]);
// =========================================================================


// функция для построения графиков, осей и разметки
function polyline(color, pts) {
    ctx.strokeStyle = color;
    ctx.beginPath();
    pts.forEach((p, i) => i ? ctx.lineTo(...p) : ctx.moveTo(...p));
    ctx.stroke();
}


// функция, которая считывает функцию из текст-бокса
function input_graff(){
    var a = input_values.input_graf.value;
    return "var y = x => " + a;
}


// событие нажатия на кнопку "Обновить"
button.onclick = function push_button(){
    
    ctx.clearRect(0, 0, canvas.width, canvas.height);
    console.log(eval(input_graff()));

    // =========================================================================
    // сделаем фрагмент клеточной бумаги,
    // здесь будет отображаться построенный график
    // вериткальные линии
    ctx.lineWidth = 0.25;
    for (var i = step*scale; i < cnvs.width; i += step*scale) { 
        polyline('#7a7979', [[i, 0], [i, cnvs.height]]);
    }
    
    // горизонтальные линии
    for (var i = step*scale; i < cnvs.height; i += step*scale) { 
        polyline('#7a7979', [[0, i], [cnvs.width, i]]);
    }
    // =========================================================================
    // =========================================================================

    // =========================================================================
    // построим оси
    // ось X 
    ctx.lineWidth = 1;
    polyline('black', [[0, cnvs.height / 2], [cnvs.width, cnvs.height / 2]]);

    // ось Y
    polyline('black', [[cnvs.width / 2, 0], [cnvs.width / 2, cnvs.height]]);
    // =========================================================================

// построение графики
    ctx.lineWidth = 2;
    let pts = [];
    for(let x = -cnvs.width/2; x<cnvs.width/2; x+=5) {
        pts.push([cnvs.width/2+x, cnvs.height/2 - y(x/scale)*scale]);
    }
    polyline('blue', pts);

    return "var y = x => " + a;
}