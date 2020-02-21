const appURL = 'https://localhost:44353/api/';
let currentUsername = null;


function renderMessages(data) {
    $('#messages').empty();

    for(let message of data){
        $('#messages')
            .append('<div class="message d-flex justify-content-start"><strong>'
                + message.user
                + '</strong>: '
                + message.content
                +'</div>')
    }
}

// first tries to load all messages from DB & then goes either to the callback function success
// or to the callback error. Data contains the response from the backend ActionResult of MessagesController

function loadMessages() {
    $.get({
        url: appURL + 'messages/all',
        success: function success(data) {
            renderMessages(data);
        },
        error: function error(error) {
            console.log(error);
        }
    });
}

function createMessage() {
    let username = currentUsername;
    let message = $('#message').val();

    if (username == null){
        alert('You can not send a message before choosing a username!');
        return;
    }

    if (message.length === 0){
        alert('You can not send empty an message!');
        return;
    }

    $.post({
        url: appURL + 'messages/create',
        headers: {
            'Content-type': 'application/json'
        },
        data: JSON.stringify({ content: message, user: username}),
        success: function success(data) {
                loadMessages();
        },
        error: function error(error) {
            console.log(error);
        }
    });


}

function chooseUsername() {
    let username = $('#username').val();          // takes the value of an input field in html

    if (username.length === 0){
        alert('You can not choose an empty username!');
        return;
    }

    currentUsername = username;
    $('#username-choice').text(currentUsername);  //it's an element
    $('#choose-data').hide();
    $('#reset-data').show();
}
function resetUsername() {
    currentUsername = null;

    $('#choose-data').show();
    $('#reset-data').hide();
}

//query selector
$('#reset-data').hide();
loadMessages();

setInterval(loadMessages, 1000 );