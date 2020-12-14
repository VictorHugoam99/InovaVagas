import React, { useEffect, useState } from 'react';
import { Link, useHistory } from 'react-router-dom';
import './style.css';
import { Pagination, Nav, } from 'react-bootstrap';

import Header from '../../components/header/index';
import Footer from '../../components/footer/index';
import CardAluno from '../../components/cardAluno/index';
import { parseJwt } from '../../services/auth';





function MinhasCandidaturas() {

    const history = useHistory();


    const [candidatura, setCandidatura] = useState(0);

    const [idVaga, setIdVaga] = useState(0);
    const [vaga, setVaga] = useState('');
    const [nomeVaga, setNomeVaga] = useState('');
    const [descricao, setDescricao] = useState('');

    const [vagas, setVagas] = useState([]);

    useEffect(() => {
        listar(parseJwt().Id);
    }, []);

    const listar = (id: number) => {

        fetch('http://localhost:5000/api/Candidatura/aluno/' + id, {
            method: 'GET',
            headers: {
                authorization: 'Bearer ' + localStorage.getItem('token-inova')
            }
        })
            .then(response => response.json())
            .then(dados => {
                setVagas(dados);
            })
            .catch(err => console.error('Ocorreu um erro:', err));
    }

    const visualizarVaga = (id : number) => {

        fetch('http://localhost:5000/api/Vaga/' + id, {
            method: 'GET',
            headers: {
                authorization: 'Bearer ' + localStorage.getItem('token-inova')
            }
        })
            .then( resp => resp.json())
            .then( dados => {
                setIdVaga(dados.idVaga);
                console.log(id);
                // localStorage.setItem( 'IdVaga', String(idVaga))
                history.push(`/visualizarVaga?id=${id}`)
            })
            .catch(err => console.error(err));
    }

    return (
        <div className="minhasCandidaturas">
            <div>
                <Header pageWrapId={'page-wrap'} outerContainerId={'outer-container'} />
            </div>

            <div className="navegacao-index">
                <Nav variant="tabs" defaultActiveKey="/minhasCandidaturas">
                    <Nav.Item>
                        <Nav.Link href="/minhasCandidaturas">Currículos enviados</Nav.Link>
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
                <h1>Visualize as vagas que você se candidatou: </h1>
                <hr />
                <div className="cardAluno-index">
                    {
                        vagas.map((item: any) => {
                            return <CardAluno tittle={item.idVagaNavigation.nomeVaga} onClick={() => visualizarVaga(item.nomeVaga)} text={item.idVagaNavigation.descricao} ></CardAluno>
                        })
                    }
                </div>
                <div className="pagination-index">
                    {/* <Pagination>
                        <Pagination.Prev />
                        <Pagination.Item active>{1}</Pagination.Item>
                        <Pagination.Item active>{2}</Pagination.Item>
                        <Pagination.Ellipsis />
                        <Pagination.Next />
                        <Pagination.Last />
                    </Pagination> */}
                </div>

            </main>

            <div>

            </div>




            <Footer />

        </div>
    )
}

export default MinhasCandidaturas;