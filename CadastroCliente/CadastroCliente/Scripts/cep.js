$(document).ready(function () {
    function limpar() {        
        $(".logradouro").val("");
        $(".bairro").val("");
        $(".cidade").val("");
        $(".uf").val("");
    }

    $(".cep").blur(function () {        
        var cep = $(this).val().replace(/\D/g, '');
        if (cep != "") {
            var validacep = /^[0-9]{8}$/;            
            if (validacep.test(cep)) {
                $(".logradouro").val("...");
                $(".bairro").val("...");
                $(".cidade").val("...");
                $(".uf").val("...");

                $.getJSON("https://viacep.com.br/ws/" + cep + "/json/?callback=?", function (dados) {
                    if (!("erro" in dados)) {                        
                        $(".logradouro").val(dados.logradouro);
                        $(".bairro").val(dados.bairro);
                        $(".cidade").val(dados.localidade);
                        $(".uf").val(dados.uf);
                    } 
                    else {                        
                        limpar();
                        alert("CEP não encontrado.");
                    }
                });
            } 
            else {                
                limpar();
                alert("Formato de CEP inválido.");
            }
        } 
        else {            
            limpar();
        }
    });
});