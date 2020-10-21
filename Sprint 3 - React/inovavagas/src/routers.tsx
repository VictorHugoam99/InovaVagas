import React from 'react';
import { BrowserRouter, Route, Redirect, Switch } from 'react-router-dom';
import {parseJwt} from './services/auth';
// import Home from './pages/home/index';
// import Login from './pages/login/index';
// import Cadastro from './pages/cadastro/index'
// import Perfil from './pages/perfil';


function Routers() {
    const RotaPrivadaAluno = ({ Component, ...rest }: any) => (
        <Route
            {...rest}
            render={props =>
                localStorage.getItem('token-inova') !== null && parseJwt().role === 'Aluno' ? (
                    <Component {...props} />
                ) : (
                        <Redirect
                            to={{ pathname: "/login", state: { from: props.location } }} />
                    )
            }
        />
    )

    const RotaPrivadaEmpresa = ({ Component, ...rest }: any) => (
        <Route
            {...rest}
            render={props =>
                localStorage.getItem('token-inova') !== null && parseJwt().role === 'Empresa' ? (
                    <Component {...props} />
                ) : (
                        <Redirect
                            to={{ pathname: "/login", state: { from: props.location } }} />
                    )
            }
        />
    )

    const RotaPrivadaAdministrador = ({ Component, ...rest }: any) => (
        <Route
            {...rest}
            render={props =>
                localStorage.getItem('token-inova') !== null && parseJwt().role === 'Administrador' ? (
                    <Component {...props} />
                ) : (
                        <Redirect
                            to={{ pathname: "/login", state: { from: props.location } }} />
                    )
            }
        />
    )

    return (
        <BrowserRouter>
            <Switch>
                {/* <RotaPrivadaAluno path="/" exact component={HomeAluno}/>
                <Route path="/login" component={Login}/>
                <Route path="/cadastro" component={Cadastro}/>
                <RotaPrivadaAluno path="/perfil" component={Perfil}/> */}
            </Switch>
        </BrowserRouter>
    )
}

export default Routers;