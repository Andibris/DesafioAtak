//adiciona a ação ao botão "enviar"
$("#get-btn").click(function() {
    Buscar();
})
//caminho base
const path = "https://webscraipinghttpsapi20221127133431.azurewebsites.net/WebScraping/search=";
function Buscar(){
    //recebe o valor digitado pelo usuário na box
    var pesquisa = $("#box").val();
    //concatena o caminho ao valor digitado e envia a requisição
    fetch(path+pesquisa).then(response => response.json()).then(valores => {
        const list = document.querySelector('#containerLista');
        //cria os elementos de lista que receberão os títulos e links
        valores.map((item) => {
            const li = document.createElement('li');
            const title = document.createElement('h4');
            const path = document.createElement('a');
            title.innerHTML = item.titulo;
            li.appendChild(title);
            path.setAttribute('href',item.link);
            path.setAttribute('target','_blank')
            path.innerHTML = item.link;
            li.appendChild(path);
            list.appendChild(li);
        });
    });
};