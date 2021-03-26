// document.getElementById('btnLogin').onClick = function () {
//     let taikhoan = document.querySelector('#txtUsername').value;
//     let matkhau = document.querySelector('#txtPassword').value;
//     axios({
//         url: 'https://localhost:5001/api/User/login',
//         method: 'post',
//         data: {
//             username: 'test',
//             password: '1'
//         },
//         responesType: 'json'
//     }).then(function(result){
//         console.log(result.data);
//     }).catch(function(error){
//         console.log(error);
//         document.querySelector('text__error').innerHTML = 'Invalid username or password';
//     })
// }

function myFunction () {
    let taikhoan = document.querySelector('#txtUsername').value;
    let matkhau = document.querySelector('#txtPassword').value;
    axios({
        url: `https://localhost:5001/api/User/login?username=${taikhoan}&password=${matkhau}`,
        method: 'post',
        responesType: 'json'
    }).then(function(result){
        console.log(result.data);
        window.location.href = 'http://127.0.0.1:5501/admin/manager/manage.html'
        console.log(error);
        document.querySelector('.text__error').innerHTML = 'Invalid username or password';
    })
}