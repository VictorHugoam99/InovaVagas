import React, { useEffect, useState } from 'react';
import { Link, useHistory } from 'react-router-dom';
import './style.css';
import { Alert, Nav, Pagination, } from 'react-bootstrap';

import Header from '../../components/header/index';
import Footer from '../../components/footer/index';




function Ofertas() {

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
        <div className="ofertas">
            <div>
                <Header pageWrapId={'page-wrap'} outerContainerId={'outer-container'} />
            </div>

            <div className="navegacao-ofertas">
                <Nav variant="tabs" defaultActiveKey="/ofertasRecebidas">
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
                <h1>Confira as propostas que as empresas te enviaram:</h1>
                <hr/>
                <div className="alert-ofertas">
                <Alert variant="danger">
                    <Alert.Heading>Oops :C</Alert.Heading>
                    <p>
                        Nenhuma vaga foi ofertada até o momento. 
                    </p>
                    <hr />
                    <p className="mb-0">
                    Mantenha o currículo atualizado e continue se esforçando! :D
                    </p>
                </Alert>
                </div>
                <div className="pagination-ofertas"> 
                <Pagination>
                    <Pagination.First />
                    <Pagination.Prev />
                    <Pagination.Item active>{1}</Pagination.Item>
                    <Pagination.Item disabled href="#">{2}</Pagination.Item>
                    <Pagination.Ellipsis />
                    <Pagination.Next />
                    <Pagination.Last />
                </Pagination>
                </div>

            </main>

            <div>

            </div>



            
            <Footer />
            
        </div>
    )
}

export default Ofertas;