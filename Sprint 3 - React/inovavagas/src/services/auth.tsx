export const usuarioAutenticado = () => localStorage.getItem("token-inova") !== null

export const parseJwt = () => {

    var token = localStorage.getItem("token-inova");

    if(token){
        var base64url = token.split('.')[1];

        var base64 = base64url.replace(/-/g, '+').replace(/_/g, '/');

        return JSON.parse(window.atob(base64));
    }
}