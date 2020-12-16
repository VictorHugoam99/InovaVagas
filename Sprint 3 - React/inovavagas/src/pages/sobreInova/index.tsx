import React from 'react';
import Header from '../../components/header/index';
import Footer from '../../components/footer/index';
import { Card, Carousel } from 'react-bootstrap';

import './style.css';
import '../../assets/styles/global.css';

import imgVermelho from '../../assets/images/inovaVermelho.png';
import imgLogoSenai from '../../assets/images/senai_Branco.png';
import imgfsenai from '../../assets/images/foto1.jpeg';
import imgfsenai2 from '../../assets/images/foto2.jpeg';
import imgfsenai3 from '../../assets/images/foto3.jpeg';

function SobreInova() {
    return (
        <div className='sobreI'>
            <Header pageWrapId={'page-wrap'} outerContainerId={'outer-container'} />

            <div className="centro">
                <div className="tittle">
                    <img src={imgVermelho} alt="logoVermelho" />
                    <h1>Bem vindes à <br/>nossa 
                        plataforma</h1>
                </div>

                <div className="txtPd">
                    <div className="comeco">
                        <p>Depois de muito debate
                        e dúvida, o nome Inova Vagas
                        surgiu com a intenção de unificar o propósito tradicional do
                        SENAI com a modernidade trazida pelos seu alunos.A plataforma tem o objetivo de automatizar os processos de oferta
                        de vagas, contratação e acompanhamento de estágios. Todos
                        os anteriores sobrecarregavam
                            de alguma forma a administra-</p>

                    </div>
                    <div className="fim">
                        <p>ção/coordenação da escola SENAI,
                        os recrutadores de empresas parceiras e os alunos.
                        O sistema conta com acessos
                        diferenciados para os três tipos de
                        usuários. Possibilitando o gerenciamento de vagas e candidatos pela
                        empresa, a administração dos cadastros de empresas e alunos pelo
                        responsável do SENAI e a proposta
                        de vagas diferenciadas para alunos
                                e ex-alunos da rede.</p>

                    </div>
                </div>



                <div className='backgraudSobre'>
                    <div className='senas'>
                        <img src={imgLogoSenai} alt="logoSenai" />
                    </div>
                </div>

                <div className="description">
                    <div className="outroComeco">
                        <p>Adipiscing enim eu turpis egestas. Ut etiam
                        sit amet nisl purus in mollis nunc. Vivamus
                        arcu felis bibendum ut. Dignissim en im sit
                        amet venenatis urna cursus eget nunc sce-
                        lerisque. Dolor sit amet consectetur adipis-
                        cing elit pellentesque habitant morbi tristi-
                        que. Duis at consectetur lorem donec.Male-
                        suada bibendum arcu vitae elementum</p>

                    </div>

                    <div className='fts'>
                        <Carousel>
                            <Carousel.Item>
                                <div className="fotinho">
                                    <img src={imgfsenai} alt="primeiro slide" />
                                </div>
                            </Carousel.Item>
                            <Carousel.Item>
                                <div className="fotinho2">
                                    <img src={imgfsenai2} alt="segundo slide" />
                                </div>
                            </Carousel.Item>
                            <Carousel.Item>
                                <div className="fotinho3">
                                    <img src={imgfsenai3} alt="terceiro slide" />
                                </div>
                            </Carousel.Item>
                        </Carousel>
                    </div>
                </div>
            </div>
            <Footer/>
        </div>
    );
}
export default SobreInova;