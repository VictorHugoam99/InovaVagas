import React, { useState, useEffect } from 'react';
import Header from '../../components/header/index';
import Footer from '../../components/footer/index';
import { Card } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import ButtonFull from '../../components/button/index'
import agendaBrancaChecked from '../../assets/images/agendachecked_Branca.png';
import inova from '../../assets/images/inovaVermelho.png';
import './style.css';

function CadastrosPendentes() {
    const [empresasDesaprovadas, setEmpresasDesaprovadas] = useState([]);
    const [isEmpresa, setIdEmpresa] = useState(0);
    const [nomeFantasia, setNomeFantasia] = useState('');
    const [email, setEmail] = useState('');
    const [telefone, setTelefone] = useState('');
    const [endereco, setendereco] = useState('');
    const [areaAtuacao, setAreaAtuacao] = useState('');
    const [cadastroAprovado, setCadastroAprovado] = useState(false);

    useEffect(() => {
        listarSemAprovar();
    }, [])

    const listarSemAprovar = () => {
        fetch('http://localhost:5000/api/Empresa/empresas', {
            method: 'GET',
            headers: {
                authorization: 'Bearer' + localStorage.getItem('token-inova')
            }
        })
            .then(resp => resp.json())
            .then(dados => {
                setEmpresasDesaprovadas(dados);
                setNomeFantasia(dados.nomeFantasia);
                setEmail(dados.email);
                setTelefone(dados.telefone);
                setAreaAtuacao(dados.areaAtuacao);
                setIdEmpresa(dados.idEmpresa);
            })
            .catch(e => console.error(e));
    }

    const aprovar = (id:any) => {
        fetch('http://localhost:5000/api/Empresa/aprovar/' + id, {
            method:'PUT',
            headers: {
                authorization: 'Bearer' + localStorage.getItem('token-inova')
            }
        })
        .then(resp => {
            if (resp.status === 204) {
                alert('Empresa aprovada com sucesso!');
            }
            else {
                alert('Não foi possível aprovar essa Empresa')
            }
        })
        .catch(e => console.error(e));
    } 
    return (
        <div className="cadastrosPendentes">
            <Header pageWrapId={'page-wrap'} outerContainerId={'outer-container'} />
            <div className="fundo">
                <div className="tittle">
                    <img src={agendaBrancaChecked} alt="cadastros pendentes" width="40px" height="40px" />
                    <h2>Cadastros Pendentes</h2>
                </div>
                <div className="corpo">
                    {
                        empresasDesaprovadas.map((item: any) => {
                            return <div className="card-container"> <Card bsPrefix="main-card">
                                <Card.Body bsPrefix="card-body">
                                    <div className="card-content">
                                        <div className="car-button-container">
                                            <div className="card-text-container">
                                                <p className="main-text">{item.nomeFantasia}</p>
                                                <p className="simple-text">{item.idUsuarioNavigation.email}</p>
                                                <p className="simple-text">{item.idUsuarioNavigation.telefone}</p>
                                                <p className="main-text2">Endereço</p>
                                                <p className="simple-text">{item.idUsuarioNavigation.endereco}</p>
                                                <p className="main-text2">Area de Atuação</p>
                                                <p className="simple-text">{item.ramoAtuacao}</p>
                                            </div>
                                            <div className="button-container">
                                                <button className="button" onClick={() => aprovar(item.idEmpresa)}>Aprovar</button>
                                                <button className="buttonVasado">Recusar</button>
                                            </div>
                                        </div>
                                        <div className="container">
                                            <Link to="/perfilEmpresa" className="linkEmpresa">Ver Perfil</Link>
                                            <Card.Img bsPrefix="card-img" src={inova}></Card.Img>
                                        </div>
                                    </div>
                                </Card.Body>
                            </Card>
                            </div>
                        })
                    }
                </div>
            </div>
            <div className="footer">
                <Footer />
            </div>
        </div>
    )
}

export default CadastrosPendentes;