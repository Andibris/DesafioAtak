window.onload = function(){
    var botao = document.getElementById('get-btn');
    botao.addEventListener('onclick',function(){
        var recebe = document.getElementById('box');
        var box = recebe.value;
        var valor = box.value;
    console.log(valor);
    var pesquisa = `https://www.google.com.br/search?q=${valor}`;
    console.log(pesquisa);
    });











};