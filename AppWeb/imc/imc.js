window.onload = function() {
    cal = document.getElementById('calc');
    kg = document.getElementById('kg');
    m = document.getElementById('m');
    imc = document.getElementById('imc');
    lectura = document.getElementById('lectura');
    calc.onclick = function() {
        if (kg.value != '' && m.value != '') {
            imcx = kg.value / (m.value * m.value);
            imc.innerHTML = imcx;
            console.log(imcx);
        } else {
            alert('Debes ingresar peso y altura');
        }
    };

}