import React from 'react';
//import o useHistoy do reac-router-dom
import {Link, useHistory} from 'react-router-dom';
//importa a verificação do token
import {parseJwt} from '../../services/auth';
//importa a extensão do menu lateral
import { slide as Menu } from 'react-burger-menu';
    // inicio importação de imagens
import logos from '../../assets/images/senaiInova.png';
import agenda from '../../assets/images/agenda_Cinza.png';
import alerta from '../../assets/images/myalerts_Cinza.png';
import candidatura from '../../assets/images/handLove_Cinza.png';
import avaliacao from '../../assets/images/avaliacao_Cinza.png';
import predio from '../../assets/images/empresasparceiras_Cinza.png';
import sobre from '../../assets/images/about_Cinza.png';
import config from '../../assets/images/config_Cinza.png';
import sair from '../../assets/images/logout_Cinza.png';
import home from '../../assets/images/home_Cinza.png'
import mais from '../../assets/images/mais_Cinza.png';
import candidato from '../../assets/images/candidato_Cinza.png'
import relatorio from '../../assets/images/lineup_Cinza.png';
import sinoNotificacao from '../../assets/images/notification_Branco.png';
import usuario from '../../assets/images/user_Cinza.png';
    // fim importação de imagens
// importa bootstrap
import 'bootstrap/dist/css/bootstrap.min.css';
import {Navbar, NavDropdown} from 'react-bootstrap';
//importação de css local e global
import '../../assets/styles/global.css';
import './style.css'

//define a interface header e os elementos  dela
interface HeaderProps {
    pageWrapId: string;
    outerContainerId: string;
}

//função header que leva como parâmetros usas principais propriedades(props)
const Header:React.FC<HeaderProps> = (props) => {
    
    //variável que chama o componente History
    let history = useHistory();

    //função logout, removendo o token do localStorage e chamando a página de usuário deslogado
    const logout =() => {
        localStorage.removeItem('token-inova');
        history.push('/');
    }

    //função menu com estrutura condicional que retorna os menus: logado, deslogado, 
    //e dos três tipos de usuários(adm, aluno e empresa)
    const menu = () => {
        //variável token que recebe o conteúdo do localStorage
        const token = localStorage.getItem('token-inova');

        //se o token for nulo ou indefinido, chama a tela login, se não, chama o menu 
        // para quando o usuário estiver deslogado
        if(token === undefined || token === null){
            // return (
                 //chamar pagina de login
            // )
        }
        else 
        {
            //logado como aluno
            if(parseJwt().Role === "Aluno"){
            return (
                //mostra o menu de aluno
                <Menu>
                        <p className="nomeAluno">Nome Aluno</p>
                        <a className="verPerfil" href="/">
                            {/* <img className="img-item" src={agenda} alt="vagas" width="20px"/> */}
                            Ver Perfil
                        </a>
                        <hr className="linha"/>
                        <a className="menu-item" href="/">
                            <img className="img-item" src={agenda} alt="vagas" width="20px"/>
                            Vagas
                        </a>
                        <a className="menu-item" href="/meusAlertas">
                            <img className="img-item" src={alerta} alt="vagas" width="20px"/>
                            Meus Alertas
                        </a>
                        <a className="menu-item" href="/avaliacoes">
                            <img className="img-item" src={candidatura} alt="vagas" width="20px"/>
                            Minhas Candidaturas
                        </a>
                        <a className="menu-item" href="/avaliacoes">
                            <img className="img-item" src={avaliacao} alt="vagas" width="20px"/>
                            Avaliações
                        </a>
                        <a className="menu-item" href="/empresasParceiras">
                            <img className="img-item" src={predio} alt="vagas" width="20px"/>
                            Empresas Parceiras
                        </a>
                        <a className="menu-item" href="/empresasParceiras">
                            <img className="img-item" src={sobre} alt="vagas" width="20px"/>
                            Sobre Inova
                        </a>
                        <hr className="linha"/>
                        <p>Conta</p>
                        <a className="menu-item" href="/empresasParceiras">
                            <img className="img-item" src={config} alt="vagas" width="20px"/>
                            Configuração
                        </a>
                        <a className="menu-item" href="" onClick={(event) => {
                            event.preventDefault();
                            logout();
                        }}>
                            <img className="img-item" src={sair} alt="vagas" width="20px"/>
                            Sair
                        </a>
                    </Menu>
            )
        }
        else
        {
            //logado como empresa
            if(parseJwt().Role === "Empresa"){
                return (
                    //mostra o menu de empresa
                    <Menu>
                        <p className="nomeAluno">Nome Empresa</p>
                        <a className="verPerfil" href="/">
                            {/* <img className="img-item" src={agenda} alt="vagas" width="20px"/> */}
                            Ver Perfil
                        </a>
                        <hr className="linha"/>
                        <a className="menu-item" href="/">
                            <img className="img-item" src={home} alt="vagas" width="20px"/>
                            Início
                        </a>
                        <a className="menu-item" href="/">
                            <img className="img-item" src={mais} alt="vagas" width="20px"/>
                            Cadastrar Nova Vaga
                        </a>
                        <a className="menu-item" href="/meusAlertas">
                            <img className="img-item" src={agenda} alt="vagas" width="20px"/>
                            Suas Vagas Postadas
                        </a>
                        <a className="menu-item" href="/avaliacoes">
                            <img className="img-item" src={avaliacao} alt="vagas" width="20px"/>
                            Avaliações
                        </a>
                        <a className="menu-item" href="/avaliacoes">
                            <img className="img-item" src={candidato} alt="vagas" width="20px"/>
                            Meus Candidatos
                        </a>
                        <a className="menu-item" href="/empresasParceiras">
                            <img className="img-item" src={relatorio} alt="vagas" width="20px"/>
                            Relatórios
                        </a>
                        <a className="menu-item" href="/empresasParceiras">
                            <img className="img-item" src={sobre} alt="vagas" width="20px"/>
                            Sobre Inova
                        </a>
                        <hr className="linha"/>
                        <p>Conta</p>
                        <a className="menu-item" href="/empresasParceiras">
                            <img className="img-item" src={config} alt="vagas" width="20px"/>
                            Configuração
                        </a>
                        <a className="menu-item" href="" onClick={(event) => {
                            event.preventDefault();
                            logout();
                        }}>
                            <img className="img-item" src={sair} alt="vagas" width="20px"/>
                            Sair
                        </a>
                    </Menu>
                )
            }
            else
            {
                //logado como administrador
                if(parseJwt().Role === "Administrador"){
                    return (
                        //mostra o menu de administrador
                    <Menu>
                        <p className="nomeAluno">Nome Aluno</p>
                        <a className="verPerfil" href="/">
                            Ver Perfil
                        </a>
                        <hr className="linha"/>
                        <a className="menu-item" href="/">
                            <img className="img-item" src={home} alt="vagas" width="20px"/>
                            Início
                        </a>
                        <NavDropdown title="Gerenciar Alunos" id="collasible-nav-dorpdown" bsPrefix="dropdown">
                            <NavDropdown.Item href="">Ver Alunos</NavDropdown.Item>
                            <NavDropdown.Item href="">Relatório de Alunos</NavDropdown.Item>
                        </NavDropdown>
                        
                        <NavDropdown title="Gerenciar Empresas" id="collasible-nav-dorpdown" bsPrefix="dropdown">
                            <NavDropdown.Item href="">Ver Empresas</NavDropdown.Item>
                            <NavDropdown.Item href="">Relatório de Empresas</NavDropdown.Item>
                            <NavDropdown.Item href="">Cadastros Pendentes</NavDropdown.Item>
                        </NavDropdown>
                        
                        <NavDropdown title="Gerenciar Vagas" id="collasible-nav-dorpdown" bsPrefix="dropdown">
                            <NavDropdown.Item href="">Ver Vagas</NavDropdown.Item>
                            <NavDropdown.Item href="">Relatório de Vagas</NavDropdown.Item>
                        </NavDropdown>
                        
                        
                        <NavDropdown title="Gerenciar Estágios" id="collasible-nav-dorpdown" bsPrefix="dropdown">
                            <NavDropdown.Item href="">Ver Estágios</NavDropdown.Item>
                            <NavDropdown.Item href="">Relatório de Estágios</NavDropdown.Item>
                            <NavDropdown.Item href="">Visitas Técnicas</NavDropdown.Item>
                            <NavDropdown.Item href="">Avaliações</NavDropdown.Item>
                        </NavDropdown>
                        
                        <hr className="linha"/>
                        <p>Conta</p>
                        <a className="menu-item" href="/empresasParceiras">
                            <img className="img-item" src={config} alt="vagas" width="20px"/>
                            Configuração
                        </a>
                        <a className="menu-item" href="" onClick={(event) => {
                                event.preventDefault();
                                logout();
                        }}>
                            <img className="img-item" src={sair} alt="vagas" width="20px"/>
                            Sair
                        </a>
                    </Menu>
                    )
                }
            }
        }
        }
        
    }

    return (
        <div className="principal">
            {/* apagar a tg menu e chamar a função menu */}
                {/* {menu()} */}
                    <Menu>
                        <a className="nome-aluno">
                            <img className="img-perfil" src={usuario} alt="vagas" width="50px"/>
                            Nome Aluno
                        </a>
                        <a className="verPerfil" href="/">
                            Ver Perfil
                        </a>
                        <hr className="linha"/>
                        <a className="menu-item" href="/">
                            <img className="img-item" src={agenda} alt="vagas" width="20px"/>
                            Vagas
                        </a>
                        <a className="menu-item" href="/meusAlertas">
                            <img className="img-item" src={alerta} alt="vagas" width="20px"/>
                            Meus Alertas
                        </a>
                        <a className="menu-item" href="/avaliacoes">
                            <img className="img-item" src={candidatura} alt="vagas" width="20px"/>
                            Minhas Candidaturas
                        </a>
                        <a className="menu-item" href="/avaliacoes">
                            <img className="img-item" src={avaliacao} alt="vagas" width="20px"/>
                            Avaliações
                        </a>
                        <a className="menu-item" href="/empresasParceiras">
                            <img className="img-item" src={predio} alt="vagas" width="20px"/>
                            Empresas Parceiras
                        </a>
                        <a className="menu-item" href="/empresasParceiras">
                            <img className="img-item" src={sobre} alt="vagas" width="20px"/>
                            Sobre Inova
                        </a>
                        <hr className="linha"/>
                        <p>Conta</p>
                        <a className="menu-item" href="/empresasParceiras">
                            <img className="img-item" src={config} alt="vagas" width="20px"/>
                            Configuração
                        </a>
                        <a className="menu-item" href="" onClick={(event) => {
                            event.preventDefault();
                            logout();
                        }}>
                            <img className="img-item" src={sair} alt="vagas" width="20px"/>
                            Sair
                        </a>
                    </Menu>
            <Navbar bsPrefix="header">
                    <Navbar.Brand bsPrefix="img">
                            <img src={sinoNotificacao} alt="notificações" width="25"/>
                    </Navbar.Brand>
                    <Navbar.Brand bsPrefix="img1">
                            <img src={logos} alt="logos senai e inova vagas" width="250"/>
                    </Navbar.Brand>
            </Navbar>
        </div>
    );
}

export default Header;