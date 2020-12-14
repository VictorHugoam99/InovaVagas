import React, { useState } from 'react';
import imgUSenaiInova from '../../assets/images/senai_Inova.png';
import './style.css';
import { Link, useHistory } from 'react-router-dom';
import CardButton from '../../components/cardButton/index';
import ButtonFull from '../../components/button/index';
import Card from 'react-bootstrap/Card';
import imgUserRed from '../../assets/images/user_Vermelho.png';
import imgPredioRed from '../../assets/images/predio_Vermelho.png';
import '../../assets/styles/global.css';

function SelecaoCadastro() {
    return (
        <div className='selecaoCadastro'>
            <div className="content">

                <div className="text">
                    <h1 className="titleS">Quem é você?</h1>
                </div>

                <div className="cards">
                    <Link to='/aCadastro'>
                        <Card bsPrefix='main-card'>
                            <Card.Body bsPrefix='card-body'>
                                <Card.Img bsPrefix='card-img' src={imgUserRed} ></Card.Img>
                                <Card.Title bsPrefix='card-title'>Aluno</Card.Title>
                            </Card.Body>
                        </Card>
                    </Link>
                    <Link to='/eCadastro'>
                        <Card bsPrefix='main-card'>
                            <Card.Body bsPrefix='card-body'>
                                <Card.Img bsPrefix='card-img' src={imgPredioRed} ></Card.Img>
                                <Card.Title bsPrefix='card-title'>Empresa</Card.Title>
                            </Card.Body>
                        </Card>
                    </Link>
                </div>

                <Link to='/' className='link'><ButtonFull name='Voltar'/></Link>
            </div>

            <div className="logos">
                <img src={imgUSenaiInova} />
            </div>
        </div>
    );
}

export default SelecaoCadastro;