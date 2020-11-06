import React from 'react';
import { BrowserRouter, Route, Redirect, Switch } from 'react-router-dom';
import {parseJwt} from './services/auth';
// import Home from './pages/home/index';
// import Login from './pages/login/index';
// import Cadastro from './pages/cadastro/index'
// import Perfil from './pages/perfil';
import Login from './pages/login/index';
import SelecaoCadastro from './pages/selecaoCadastro/index';
import AlunoCadastro from './pages/alunoCadastro/index';
import EmpresaCadastro from './pages/empresaCadastro/index';
import HomeAdm from './pages/homeAdm';
import HomeAluno from './pages/homeAluno';
import VisualizarVaga from './pages/visualizarVaga';


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
                <RotaPrivadaAluno path="/aluno" exact component={HomeAluno}/>
                <RotaPrivadaAluno path="/visualizarVaga" component={VisualizarVaga}/>
                {/* <Route path="/cadastro" component={Cadastro}/>
            <RotaPrivadaAluno path="/perfil" component={Perfil}/> */}
                <Route path='/' exact component={Login}/>
                <Route path="/selecaoCadastro" component={SelecaoCadastro}/>
                <Route path="/aCadastro" component={AlunoCadastro}/>
                <Route path="/eCadastro" component={EmpresaCadastro}/>
                <RotaPrivadaAdministrador path="/admin" component={HomeAdm}/>
            </Switch>
        </BrowserRouter>
    )
}

export default Routers;