import React, { useState, useEffect } from 'react';
import { Link, useHistory } from 'react-router-dom';
import Header from '../../components/header/index'
import Footer from '../../components/footer/index';
import agenda from '../../assets/images/agenda_Cinza.png';
import inova from '../../assets/images/inovaVermelho.png';
import editar from '../../assets/images/canetinha_Cinza.png';
import apagar from '../../assets/images/lixo_Cinza.png';
import { parseJwt } from '../../services/auth';
import './style.css';
import { Card } from 'react-bootstrap';
import { Modal } from 'react-bootstrap';
import ButtonFull from '../../components/button/index';

function SuasVagasPostadas() {
    const history = useHistory();

    const [idVaga, setIdVaga] = useState(0);
    const [vaga, setVaga] = useState('');
    const [vagas, setVagas] = useState([]);
    const [idEmpresa, setIdEmpresa] = useState(0);

    const [show, setShow] = useState(false);

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);


    useEffect(() => {
        listarVagaPorEmpresa(parseJwt().Id);
    }, []);

    const listarVagaPorEmpresa = (id: number) => {
        fetch('http://localhost:5000/api/Vaga/empresa/' + id, {
            method: 'GET',
            headers: {
                authorization: 'Bearer' + localStorage.getItem('token-inova')
            }
        })
            .then(resp => resp.json())
            .then(dados => {
                setVagas(dados);
                console.log(vagas);
            })
            .catch(err => console.error(err));
    }

    const trash = (id: number) => {
        fetch('http://localhost:5000/api/Vaga/' + id, {
            method: 'DELETE',
            headers: {
                authorization: 'Bearer' + localStorage.getItem('token-inova')
            }
        })
            .then(resp => resp.json())
            .catch(e => console.error(e));
    }

    const visualizarVagaEditar = (id: number) => {
        fetch('http://localhost:5000/api/Vaga/' + id, {
            method: 'GET',
            headers: {
                authorization: 'Bearer ' + localStorage.getItem('token-inova')
            }
        })
            .then(resp => resp.json())
            .then(dados => {
                setIdVaga(dados.idVaga);
                console.log(id);
                // localStorage.setItem( 'IdVaga', String(idVaga))
                history.push(`/editarVaga?id=${id}`)
            })
            .catch(err => console.error(err));
    }

    const visualizarVagaCandidatos = (id: number) => {
        fetch('http://localhost:5000/api/Vaga/' + id, {
            method: 'GET',
            headers: {
                authorization: 'Bearer ' + localStorage.getItem('token-inova')
            }
        })
            .then(resp => resp.json())
            .then(dados => {
                setIdVaga(dados.idVaga);
                console.log(id);
                // localStorage.setItem( 'IdVaga', String(idVaga))
                history.push(`/candidatosVaga?id=${id}`)
            })
            .catch(err => console.error(err));
    }
    return (
        <div className="vagasPostadas">
            <Header pageWrapId={'page-wrap'} outerContainerId={'outer-container'} />
            <div className="titulo-container">
                <img src={agenda} alt="vagas postadas" width="25px" height="35px" />
                <h2 className="titulo">Vagas Postadas</h2>
            </div>
            <div className="CardVaga">
                {
                    vagas.map((item: any) => {
                        return <div className="cardVaga">
                            
                                <Card bsPrefix="main-card">
                                    <Card.Body bsPrefix="card-body">
                                        <div className="cardText-container">
                                            <Card.Title bsPrefix="card-tittle">{item.nomeVaga}</Card.Title>
                                            <div className="content-container">
                                                <Card.Text bsPrefix="card-text1">Descrição da vaga:</Card.Text>
                                                <Card.Text bsPrefix="card-text">{item.descricao}</Card.Text>
                                            </div>
                                        </div>
                                        <div className="imagens">
                                            <div className="imgEmpresa-container">
                                                <Card.Img src={inova} bsPrefix="imgEmpresa" ></Card.Img>
                                                <Link className="link-candidatos" to="/candidatosVaga" onClick={() => visualizarVagaCandidatos(item.idVaga)}>Ver Candidatos</Link>
                                            </div>
                                            <div className="atalhos">
                                                <button onClick={() => visualizarVagaEditar(item.idVaga)}>
                                                    <img src={editar} />
                                                </button>
                                                <button onClick={handleShow}>
                                                    <img src={apagar} />
                                                </button>
                                            </div>
                                            <Modal show={show} onHide={handleClose}>
                                                <Modal.Header closeButton>
                                                    <Modal.Title>Atenção!</Modal.Title>
                                                </Modal.Header>
                                                <Modal.Body>Deseja apagar essa vaga?</Modal.Body>
                                                <Modal.Footer>
                                                    <ButtonFull name="Sim" onClick={() => trash(item.idVaga)} />
                                                    <ButtonFull name="Não" onClick={handleClose} />
                                                </Modal.Footer>
                                            </Modal>
                                        </div>

                                    </Card.Body>
                                </Card>
                        </div>
                    })
                }
            </div>
            <Footer />
        </div>
    )
}

export default SuasVagasPostadas;