import React, { useState, useEffect } from 'react';
import { parseJwt } from '../../services/auth';
import Header from '../../components/header/index';
import Footer from '../../components/footer/index';
import './style.css';
import agenda from '../../assets/images/agenda_Branca.png';
import { Card } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import aluno from '../../assets/images/pessoa.png';


function CandidatosVaga() {
    const [nomeAluno, setNomeAluno] = useState('');
    const [NomeVaga, setNomeVaga] = useState('');
    const [candidaturas, setCandidaturas] = useState([]);

    const queryString = window.location.search;

    const urlParams = new URLSearchParams(queryString);

    const idVisualizar = urlParams.get('id');

    useEffect(() => {
        listarCandidaturasPorVaga(idVisualizar!);
        visualizarNomeVaga(idVisualizar!);
    }, []);

    const listarCandidaturasPorVaga = (id: any) => {
        fetch('http://localhost:5000/api/Candidatura/vaga/' + id, {
            method: 'GET',
            headers: {
                authorization: 'Bearer' + localStorage.getItem('token-inova')
            }
        })
            .then(resp => resp.json())
            .then(dados => {
                setCandidaturas(dados);
                setNomeAluno(dados.idAlunoNavigation.nome);
                console.log(candidaturas);
            })
            .catch(e => console.error(e));
    }

    const visualizarNomeVaga = (id: any) => {
        fetch('http://localhost:5000/api/Vaga/' + id, {
            method: 'GET',
            headers: {
                authorization: 'Bearer ' + localStorage.getItem('token-inova')
            }
        })
            .then(resp => resp.json())
            .then(dados => {
                setNomeVaga(dados.nomeVaga);
                console.log(id);
            })
            .catch(err => console.error(err));
    }

    // const getAlunoPorCandidatura = (id: number) => {
    //     fetch()
    // }
    return (
        <div className="visualizarVaga">
            <Header pageWrapId={'page-wrap'} outerContainerId={'outer-container'} />
            <div className="visualizar-content">
                <div className="fundo-page">
                    <div className="title">
                        <img src={agenda} />
                        <div className="title-text">
                            <h2>Candidatos</h2>
                            <h3>{NomeVaga}</h3>
                        </div>
                    </div>
                    <div className="card-container-aluno">
                        {
                            candidaturas.map((item: any) => {
                                return <div className="cardEmpresa">
                                    <Card bsPrefix="main-card">
                                        <Card.Body bsPrefix="card-body">
                                            <Card.Title bsPrefix="card-title">{item.idAlunoNavigation.nome}</Card.Title>
                                            <Card.Img bsPrefix="card-img" src={aluno}></Card.Img>
                                            <Link className="perfil" to="/perfilAluno">Ver Perfil</Link>
                                        </Card.Body>
                                    </Card>
                                </div>

                            })
                        }
                    </div>

                </div>
            </div>
            <Footer />
        </div>
    );
}

export default CandidatosVaga;