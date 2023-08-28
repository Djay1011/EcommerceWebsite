var font = document.querySelector('.navss');
var increase = document.querySelector('.button1')
;
var decrease = document.querySelector('.button2')
;

var fontSize = 20;

increase.addEventListener('click',()=>{
    fontSize = fontSize + 5;
    font.style.fontSize = fontSize + 'px';
})

decrease.addEventListener('click',()=>{
    fontSize = fontSize - 5;
    font.style.fontSize = fontSize + 'px';
})


var text = document.querySelector('.collection');
var increase = document.querySelector('.button1')
;
var decrease = document.querySelector('.button2')
;

var textSize = 20;

increase.addEventListener('click',()=>{
    textSize = textSize + 5;
    text.style.fontSize = textSize + 'px';
})

decrease.addEventListener('click',()=>{
    textSize = textSize - 5;
    text.style.fontSize = textSize + 'px';
})
