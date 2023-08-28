if (document.readyState == "loading"){
    document.addEventListener("DOMContentLoaded", ready);
}
else{
    ready();
}

function ready(){
    var removecart = document.getElementsByClassName('remove')
    console.log(removecart)
    for (var i = 0; i < removecart.length; i++){
        var button = removecart[i]
        button.addEventListener("click", removecartitem);
    }

    var quantityInputs = document.getElementsByClassName('quantitys')
    for (var i = 0; i < quantityInputs.length; i++){
        var input = quantityInputs[i]
        input.addEventListener('change',quantitychanged);
    }

    var addtocart = document.getElementsByClassName('add-to-cart')
    for (var i = 0; i < quantityInputs.length; i++){
        var button = addtocart[i]
        button.addEventListener('click'
        , addtocartclicked);
    }
}

function removecartitem(event){
    var buttonClicked = event.target;
    buttonClicked.parentElement.remove();
    updatecartTotal();
}

function quantitychanged(event){
    var input = event.target
    if (isNaN(input.value) || input.value <= 0){
        input.value = 1
    }
    updatecartTotal();
}

function addtocartclicked(event) {
    var button = event.target
    var items = button.parentElement.parentElement
    var title = items.getElementsByClassName('product-title')[0].innerTest
    var prices = items.getElementsByClassName('product-price')[0].innerTest
    var image = items.getElementsByClassName('top-img')[0].src
    console.log(title,prices,image)
}


function updatecartTotal(){
    var cartitems = document.getElementsByClassName('cart')[0];
    var cartBoxes = cartitems.getElementsByClassName('box');
    var total = 0;
    for (var i = 0; i < cartBoxes.length; i++){
        var cartBox = cartBoxes[i]
        var price = cartBox.getElementsByClassName('totals')[0]
        var quantity = cartBox.getElementsByClassName('quantitys')[0]
        var currency = parseFloat(price.innerText.replace('£', ''))
        var amount = quantity.value;
        total = total + (currency * amount);
    }
    total = Math.round(total * 100) / 100
    document.getElementsByClassName('subtotals')[0].innerText = '£' + total;
}