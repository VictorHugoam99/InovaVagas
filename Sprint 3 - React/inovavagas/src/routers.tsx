import React from 'react';
import { BrowserRouter, Route, Redirect, Switch } from 'react-router-dom';
import {parseJwt} from './services/auth';
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
import CadastrosPendentes from './pages/Cadastros_Pendentes';
import SuasVagasPostadas from './pages/SuasVagasPostadas/index'
import HomeEmpresa from './pages/homeEmpresa/index';
import CadastrarVagas from './pages/cadastroVaga/index';
import EmpresasParceiras from './pages/Empresas_Parceiras';
import PerfilEmpresa from './pages/perfilEmpresa';
import EditarVaga from './pages/editarVaga';
import CandidatosVaga from './pages/candidatosVaga/index';
import Configuracao from './pages/configuracoes';
import PerfilAdm from './pages/perfilAdm/index';
import MinhasCandidaturas from './pages/minhasCandidaturas/index';
import Acompanhamento from './pages/minhasCandidaturas/acompanhamento';
import Ofertas from './pages/minhasCandidaturas/ofertas';
import SobreInova from './pages/sobreInova/index';



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
                <RotaPrivadaAluno path="/empresasParceiras" component={EmpresasParceiras}/>
                <RotaPrivadaAluno path="/perfilEmpresa" component={PerfilEmpresa}/>
                <RotaPrivadaAluno path="/minhasCandidaturas" component={MinhasCandidaturas}/>
                <RotaPrivadaAluno path="/acompanhamentoSeletivo" component={Acompanhamento}/>
                <RotaPrivadaAluno path="/ofertasRecebidas" component={Ofertas}/>
                <RotaPrivadaAluno path="/sobreInova" component={SobreInova}/>
                {/* <Route path="/cadastro" component={Cadastro}/>
            <RotaPrivadaAluno path="/perfil" component={Perfil}/> */}
                <Route path='/' exact component={Login}/>
                <Route path="/selecaoCadastro" component={SelecaoCadastro}/>
                <Route path="/aCadastro" component={AlunoCadastro}/>
                <RotaPrivadaAdministrador path="/cadastrosPendentes" component={CadastrosPendentes}/>
                <Route path="/eCadastro" component={EmpresaCadastro}/>
                <Route path="/vagasPostadas" component={SuasVagasPostadas}/>
                <RotaPrivadaAdministrador path="/admin" component={HomeAdm}/>
                <RotaPrivadaEmpresa path="/empresa" exact component={HomeEmpresa}/>
                <RotaPrivadaEmpresa path="/cadastroVaga" component={CadastrarVagas}/>  
                <RotaPrivadaEmpresa path="/vagasPostadas" component={SuasVagasPostadas}/> 
                <RotaPrivadaEmpresa path="/editarVaga" component={EditarVaga}/> 
                <RotaPrivadaEmpresa path="/sobreInova" component={SobreInova}/> 
                <RotaPrivadaEmpresa path="/candidatosVaga" component={CandidatosVaga}/> 
                <RotaPrivadaAdministrador path="/perfilAdm" component={PerfilAdm}/> 
                <RotaPrivadaEmpresa path="/config" component={Configuracao}/> 
                <RotaPrivadaAdministrador path="/config" component={Configuracao}/> 
                <RotaPrivadaAdministrador path="/sobreInova" component={SobreInova}/> 
                <RotaPrivadaAluno path="/config" component={Configuracao}/> 
            </Switch>
        </BrowserRouter>
    )
}

export default Routers;