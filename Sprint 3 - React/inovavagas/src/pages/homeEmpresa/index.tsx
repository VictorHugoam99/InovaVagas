import React, { useState } from 'react';
import {Link} from 'react-router-dom';
import Header from '../../components/header';
import SearchBar from '../../components/searchBar';
import Card from 'react-bootstrap/Card';

import './style.css';
import '../../assets/styles/global.css';

import imgHome from '../../assets/images/home_Cinza.png';
import imgMais from '../../assets/images/mais_Cinza.png';
import imgAgenda from '../../assets/images/agenda_Cinza.png';
import imgAvaliação from '../../assets/images/avaliacao_Cinza.png';
import imgCandidato from '../../assets/images/candidato_Cinza.png';

import CardButton from '../../components/cardButton';
import Input from '../../components/input';
import ButtonFull from '../../components/button';

import Footer from '../../components/footer';

function HomeEmpresa() {
    return (
        <div className='Empresa'>
            <Header pageWrapId={'page-wrap'} outerContainerId={'outer-container'} />

                <div className='back'>
                    
                <div className="title">
                    <img src={imgHome} alt="casinha" width="5px"/>
                    <h1>Inicio</h1>                    
                </div>

                <div className="barraP">
                    <SearchBar> </SearchBar>
                    <div className='bus'>
                    <ButtonFull name='Buscar' tamanho='lg' />
                    </div>
                </div>
                

                <div className="cards-line">
                    <div className='um'>
                        <Link to="/cadastroVaga">
                            <Card bsPrefix='main-card'>
                                <Card.Body bsPrefix='card-body'>
                                    <Card.Img bsPrefix='card-img' src={imgMais} ></Card.Img>
                                    <Card.Title bsPrefix='card-title'>Nova Vaga</Card.Title>
                                    <Card.Text bsPrefix='card-text'>Cadastre novas vagas</Card.Text>
                                </Card.Body>
                            </Card>
                    </Link>
                    <Link to="/vagasPostadas">
                    <Card bsPrefix='main-card'>
                        <Card.Body bsPrefix='card-body'>
                            <Card.Img bsPrefix='card-img' src={imgAgenda} ></Card.Img>
                            <Card.Title bsPrefix='card-title'>Vagas Postadas</Card.Title>
                            <Card.Text bsPrefix='card-text'>Visualize as vagas já cadastradas aqui</Card.Text>
                        </Card.Body>
                    </Card>
                    </Link>
                    </div>

                    <div className='dois'>
                    <Card bsPrefix='main-card'>
                        <Card.Body bsPrefix='card-body'>
                            <Card.Img bsPrefix='card-img' src={imgAvaliação} ></Card.Img>
                            <Card.Title bsPrefix='card-title'>Avaliações</Card.Title>
                            <Card.Text bsPrefix='card-text'>Acesse as avaliações dos candidados aqui</Card.Text>
                        </Card.Body>
                    </Card>
                    <Card bsPrefix='main-card'>
                        <Card.Body bsPrefix='card-body'>
                            <Card.Img bsPrefix='card-img' src={imgCandidato} ></Card.Img>
                            <Card.Title bsPrefix='card-title'>Meus Candidatos</Card.Title>
                            <Card.Text bsPrefix='card-text'>Visualize os candidatos salvos aqui</Card.Text>
                        </Card.Body>
                    </Card>
                    </div>
                    
                </div>
                <Footer/>
                </div>
            </div>
    );
}

export default HomeEmpresa;