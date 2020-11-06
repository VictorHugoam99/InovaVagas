import React, {useEffect, useState } from 'react';
import './style.css';
import Header from '../../components/header/index';
// import Footer from '../../components/footer/index';
import {Col, Container, Row} from 'react-bootstrap';
import inova from '../../assets/images/inovaVermelho.png';
import Button from '../../components/button/index';

function VisualizarVaga() {



    return (
        <div>
            <Header pageWrapId={'page-wrap'} outerContainerId={'outer-container'} />
            <main>
                <Container>
                    <Row xs={1} md={2} lg={9}>
                        <Col><h1> Nome da vaga disponivel </h1></Col>
                        <Col> <img src={inova}></img> </Col>
                        <Col><h2> Nome da empresa </h2></Col>
                    </Row>
                    <Row xs={1}>
                        <Col><h2>Endereço</h2></Col>
                        <Col><h2>Salário</h2></Col>
                    </Row>
                    <div className="btn">
                    <Button name="Candidatar-se"></Button> 
                    <Button name="Voltar p/ vagas"></Button>
                    <a href="#"> Visualizar perfil da empresa </a>
                    </div>
                    <hr/>
                    <div className="desc">
                    <Row xs={2}>
                        <Col>Lorem ipsum dolor sit amet, consectetur adipiscing elit, 
                        sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. 
                        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi
                        ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit
                        in voluptate velit esse cillum dolore eu fugiat nulla pariatur.
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit, 
                        sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit, 
                        sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
                        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi
                        ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit
                        in voluptate velit esse cillum dolore eu fugiat nulla pariatur.
                        </Col>
                    </Row>
                    </div>
                
                </Container>
            </main>
            {/* <Footer /> */}
        </div>
    )
}

export default VisualizarVaga;