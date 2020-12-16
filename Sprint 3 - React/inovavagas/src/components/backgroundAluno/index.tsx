import React, { useState, useEffect } from 'react';
import { parseJwt } from '../../services/auth';
import './style.css';
// import {Container, Col, Row, Image} from 'react-bootstrap';
import aluno from '../../assets/images/lorraine.jpg';
import facebook from '../../assets/images/facebook_Branco.png';
import instagram from '../../assets/images/insta_Branco.png';
import twitter from '../../assets/images/tt_Branco.png';

function BackgroundAluno() {
    const [idAluno, setIdAluno] = useState(0);
    const [nome, setNome] = useState('')
    const [tituloPerfil, setTituloPerfil] = useState('');

    useEffect(() => {
        listarAlunoPorId(parseJwt().Id)
    }, []);

    const listarAlunoPorId = (id: number) => {
        fetch('http://localhost:5000/api/Aluno/' + id, {
            method: 'GET',
            headers: {
                authorization: 'Bearer' + localStorage.getItem('token-inova')
            }
        })
            .then(resp => resp.json())
            .then(data => {
                setIdAluno(data.idAluno);
                setNome(data.nome);
                setTituloPerfil(data.tituloPerfil);
            })
            .catch(e => console.error(e))
    }

    return (

        <div className="all">
            <div className="alinhamento">
                <div className="cab">
                    <div className="box">
                        <h1>{nome}</h1>
                        <h3>{tituloPerfil}</h3>
                        {/* <div className="imgs-container">
                            <img src={facebook} alt="link facebook" width="30px" />
                            <img src={instagram} alt="link instagram" width="30px" />
                            <img src={twitter} alt="link twitter" width="30px" />
                        </div> */}
                    </div>
                    <div className="imagem">
                        <img src={aluno} />
                    </div>
                </div>
            </div>
        </div>
    )
}
export default BackgroundAluno;

