import React from 'react';
import { BrowserRouter, Route, Redirect, Switch } from 'react-router-dom';
import {parseJwt} from './services/auth';
// import Home from './pages/home/index';
// import Login from './pages/login/index';
// import Cadastro from './pages/cadastro/index'
// import Perfil from './pages/perfil';
import Teste from './pages/teste/teste';
import Login from './pages/login/index';
import SelecaoCadastro from './pages/selecaoCadastro/index';
import AlunoCadastro from './pages/alunoCadastro/index';


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
                <Route path="/cadastro" component={Cadastro}/>
            <RotaPrivadaAluno path="/perfil" component={Perfil}/> */}
                <Route path='/' exact component={Teste}/>
                <Route path="/login" component={Login}/>
                <Route path="/selecaoCadastro" component={SelecaoCadastro}/>
                <Route path="/aCadastro" component={AlunoCadastro}/>
                {/* <Route path="/empresaCadastro" component={EmpresaCadastro}/> */}
            </Switch>
        </BrowserRouter>
    )
}

export default Routers;