import React, { useState } from 'react';
import imgUSenaiInova from '../../assets/images/senaiInova.png';
import './style.css';
import { Link, useHistory } from 'react-router-dom';
import CardButton from '../../components/cardButton/index';
import ButtonFull from '../../components/button/index';
import imgUserRed from '../../assets/images/user_Vermelho.png';
import imgMaletaRed from '../../assets/images/maleta_Vermelha.png';
import imgAgendaRed from '../../assets/images/agenda_Vermelha.png';
import imgDashboard from '../../assets/images/dashboard_Branco.png';
import imgPredioRed from '../../assets/images/predio_Vermelho.png';
import Header from '../../components/header/index'
import '../../assets/styles/global.css';

function HomeAdm() {
    return (
        <div className='homeAdm'>
            <Header pageWrapId={'page-wrap'} outerContainerId={'outer-container'} />

            <div className='content-homeAdm'>
                <div className="background">
                    <div className="title">
                        <img src={imgDashboard} alt="ícone da dashboard" />
                        <h1>Dashboard</h1>
                    </div>
                    <p>Gerencie as informações do site</p>
                </div>

                <div className="cards-line">
                    <CardButton title='Ver Alunos' img={imgUserRed} />
                    <CardButton title='Ver Vagas' img={imgAgendaRed} />
                    <CardButton title='Ver Empresas' img={imgPredioRed} />
                    <CardButton title='Ver Estágios' img={imgMaletaRed} />
                </div>

                <h2>Relatórios Gerais</h2>

                <div className="bottom-card-line">

                    <div className="info-aluno">
                        <p className='aluno-title'>Alunos</p>
                        <h2>873</h2>
                        <p>Alunos Cadastrados</p>
                        <div className="info-link">
                            <Link to=''><h3>Ver Mais</h3></Link>
                        </div>
                    </div>

                    <div className="info-vaga">
                        <p className='vaga-title'>Vagas</p>
                        <h2>97</h2>
                        <p>Vagas Disponíveis</p>
                        <div className="info-link">
                            <Link to=''><h3>Ver Mais</h3></Link>
                        </div>
                    </div>

                    <div className="info-empresa">
                        <p className='empresa-title'>Empresas</p>
                        <h2>45</h2>
                        <p>Empresas Cadastradas</p>
                        <div className="info-link">
                            <Link to=''><h3>Ver Mais</h3></Link>
                        </div>
                    </div>

                    <div className="info-estagio">
                        <p className='estagio-title'>Estágios</p>
                        <h2>149</h2>
                        <p>Estágios Em Andamento</p>
                        <div className="info-link">
                            <Link to=''><h3>Ver Mais</h3></Link>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    );
}

export default HomeAdm;