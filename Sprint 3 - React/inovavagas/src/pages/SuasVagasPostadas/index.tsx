import React, { useState, useEffect } from 'react';
import { Link, useHistory } from 'react-router-dom';
import Header from '../../components/header/index'
import Footer from '../../components/footer/index';
import CardVaga from '../../components/cardVaga/index';
import agenda from '../../assets/images/agenda_Cinza.png';
import { parseJwt } from '../../services/auth';
import './style.css';

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
    return (
        <div className="vagasPostadas">
            <Header pageWrapId={'page-wrap'} outerContainerId={'outer-container'} />
            <div className="titulo-container">
                <img src={agenda} alt="vagas postadas" width="20px" height="30px" />
                <h2 className="titulo">Vagas Postadas</h2>
            </div>
            <hr className="line" />
            <div className="cardVaga">
                {
                    vagas.map((item: any) => {
                        return <div className="cardVaga-container"><CardVaga tittle={item.nomeVaga} text={item.descricao} /></div>
                    })
                }
            </div>
            <Footer />
        </div>
    )
}

export default SuasVagasPostadas;