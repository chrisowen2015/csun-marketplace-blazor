

function displayButtons(element) {
    var style = {
        layout: 'vertical',
        color: 'blue',
        shape: 'rect',
        label: 'paypal'
    }

    var createOrder = {

    }

    paypal.Buttons({ style }).render(element);
}