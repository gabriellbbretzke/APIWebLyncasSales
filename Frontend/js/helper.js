var campoCpf = document.getElementById('CPF');

//-----------------------------------------VALIDA CAMPO CPF
function alertaParaCpf (numeroCPF){
    if (TestaCPF(numeroCPF) == true || numeroCPF==''){
        return true;
    } else {
        campoCPF.id = 'CPFerro';
        setTimeout(function(){
          campoCPF.id = 'CPF';
        }, 5000);
        return false;
    }
}
//-----------------------------------------TESTAR CPF VÁLIDO OU NÃO
function TestaCPF(strCPF) {
    var Soma;
    var Resto;
    Soma = 0;
    strCPF = strCPF.replace(/\./g, '');
    strCPF = strCPF.replace(/\-/g, '');
    if (strCPF == "00000000000") return false;

    for (i=1; i<=9; i++) Soma = Soma + parseInt(strCPF.substring(i-1, i)) * (11 - i);
    Resto = (Soma * 10) % 11;

    if ((Resto == 10) || (Resto == 11))  Resto = 0;
    if (Resto != parseInt(strCPF.substring(9, 10)) ) return false;

    Soma = 0;
    for (i = 1; i <= 10; i++) Soma = Soma + parseInt(strCPF.substring(i-1, i)) * (12 - i);
    Resto = (Soma * 10) % 11;

    if ((Resto == 10) || (Resto == 11))  Resto = 0;
    if (Resto != parseInt(strCPF.substring(10, 11) ) ) return false;
    return true;
}
//-----------------------------------------MÁSCARA PARA CAMPO CPF
function criaMascaraCPF(mascaraInput) {
    const maximoInput = document.getElementById('CPF').maxLength;
    let valorInput = document.getElementById('CPF').value;
    let valorSemPonto = document.getElementById('CPF').value.replace(/([^0-9])+/g, "");
    const mascaras = {
        CPF: valorInput.replace(/[^\d]/g, "").replace(/(\d{3})(\d{3})(\d{3})(\d{2})/, "$1.$2.$3-$4")
    };

    valorInput.length === maximoInput ? document.getElementById('CPF').value = mascaras[mascaraInput] : document.getElementById('CPF').value = valorSemPonto;
}
//-----------------------------------------MÁSCARA PARA CAMPO TELEFONE
function criaMascaraTelefone(mascaraInput) {
    const maximoInput = document.getElementById('telefone').maxLength;
    let valorInput = document.getElementById('telefone').value;
    let valorSemPonto = document.getElementById('telefone').value.replace(/([^0-9])+/g, "");
    const mascaras = {
      telefone: valorInput.replace(/[^\d]/g, "").replace(/(\d{3})(\d{5})(\d{4})/, "$1 $2-$3")
    };

    valorInput.length === maximoInput ? document.getElementById('telefone').value = mascaras[mascaraInput] : document.getElementById('telefone').value = valorSemPonto;
}
//-------------------------------------BOTÃO VOLTAR DA PÁGINA
function botaoVoltar () {
  window.history.back();
}
//-------------------------ADICIONAR MÁSCARA AO CAMPO VALOR UNITÁRIO
function criarMascaraValorUnitario() {
  const vlrUnitarioDosCampos = document.querySelectorAll('#vlrunitario');
  vlrUnitarioDosCampos.forEach(event => {
      var v = event.value.replace(/\D/g,"");        
      v = (v/100).toFixed(2) + "";
      v = v.replace(".", ",");
      v = v.replace(/(\d)(\d{3})(\d{3}),/g, "R$ $1.$2.$3,");
      event.value = v;
  });
}