var Firstimg = document.getElementById("Firstimg");
var relatedimg = document.getElementsByClassName("related-img");

relatedimg[0].onclick = function(){
    Firstimg.src = relatedimg[0].src;
}
relatedimg[1].onclick = function(){
    Firstimg.src = relatedimg[1].src;
}
relatedimg[2].onclick = function(){
    Firstimg.src = relatedimg[2].src;
}
relatedimg[3].onclick = function(){
    Firstimg.src = relatedimg[3].src;
}


var Insideimg = document.getElementById("Insideimg");
var nextimg = document.getElementsByClassName("next-img");

nextimg[0].onclick = function(){
    Insideimg.src = nextimg[0].src;
}
nextimg[1].onclick = function(){
    Insideimg.src = nextimg[1].src;
}
nextimg[2].onclick = function(){
    Insideimg.src = nextimg[2].src;
}
nextimg[3].onclick = function(){
    Insideimg.src = nextimg[3].src;
}