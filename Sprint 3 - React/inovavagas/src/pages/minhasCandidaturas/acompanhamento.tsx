import React, { useEffect, useState } from 'react';
import { Link, useHistory } from 'react-router-dom';
import './style.css';
import {Card, ProgressBar, Nav } from 'react-bootstrap';

import Header from '../../components/header/index';
import Footer from '../../components/footer/index';
import CardAluno from '../../components/cardAluno/index';



function Acompanhamento() {

    // const history = useHistory();

    // const [idVaga, setIdVaga] = useState(0);
    // const [vaga, setVaga] = useState('');

    // const[vagas, setVagas] = useState([]);

    // useEffect(() => {
    //     listar();
    // }, []);

    // const visualizarVaga = (nomeVaga : string) => {

    //     fetch('http://localhost:5000/api/Vaga/' + nomeVaga, {
    //         method: 'GET',
    //         headers: {
    //             authorization: 'Bearer ' + localStorage.getItem('token-inova')
    //         }
    //     })
    //         .then( resp => resp.json())
    //         .then( dados => {
    //             setVaga(dados.nomeVaga);
    //             localStorage.setItem( 'Vaga' ,vaga)
    //             history.push('/visualizacaoVaga')
    //         })
    //         .catch(err => console.error(err));
    // }

    return (
        <div className="acompanhamento">
            <div>
                <Header pageWrapId={'page-wrap'} outerContainerId={'outer-container'} />
            </div>

            <div className="navegacao-acompanhamento">
                <Nav variant="tabs" defaultActiveKey="/acompanhamentoSeletivo">
                    <Nav.Item>
                        <Nav.Link href="/minhasCandidaturas">Curriculos enviados</Nav.Link>
                    </Nav.Item>
                    <Nav.Item>
                        <Nav.Link href="/acompanhamentoSeletivo">Acompanhamento seletivo</Nav.Link>
                    </Nav.Item>
                    <Nav.Item>
                        <Nav.Link href="/ofertasRecebidas">Ofertas recebidas</Nav.Link>
                    </Nav.Item>
                </Nav>
            </div>
            <main>
                <h1 className="h1Acompanhamento">Acompanhe por aqui o processo de uma candidatura:</h1>
                <hr/>
                <Card bsPrefix="card-acompanhamento ">
                    <Card.Body bsPrefix="card-body">
                        <div className="progressBar-acompanhamento">
                        <ProgressBar>
                            <ProgressBar striped variant="danger" animated now={25} label={'Seleção'} key={1} />
                            <ProgressBar striped variant="danger" animated now={25} label={'Agendamento da entrevista'} key={2} />
                            <ProgressBar striped variant="danger" animated now={25} label={'Entrevista'} key={3} />
                        </ProgressBar>
                        </div>
                    </Card.Body>
                </Card>
            </main>

            <div>

            </div>




            <Footer />
        </div>
    )
}

export default Acompanhamento;