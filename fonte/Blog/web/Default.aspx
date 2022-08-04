<%@ Page Language="C#" MasterPageFile="/biblioteca/Aparencia/Principal.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="web.Default" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <style>
        .vitrine {
            border: 1px solid #d5d3d3;
            margin-bottom: 15px;
        }

        .img-vitrine {
            background-image: url('/imagem/quadro.jpg');
            background-size: 100% 100%;
            height: 45vh;
        }

        .vitrine-texto {
            padding: 10px 20px;
            background-color: white;
            border-top: 1px solid #d5d3d3;
        }

        .post {
            height: 200px;
            background-color: white;
            display: flex;
            margin-bottom: 15px;
        }

        .post-img {
            height: 200px;
            width: auto;
        }

        .post-texto {
            padding: 10px 20px;
        }
    </style>
</asp:Content>

<asp:Content ContentPlaceHolderID="AreaPrincipal" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="offset-2 col-8">

                <div class="vitrine">
                    <div class="img-vitrine">
                    </div>
                    <div class="vitrine-texto">
                        <h3>Lorem ipsum dolor sit amet consectetur</h3>
                        <small>- 27/07/2022</small>
                        <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Facilis, saepe rem reprehenderit dignissimos quos ducimus impedit dolores natus quas soluta provident consequuntur temporibus optio, nihil in quam quis molestiae. Accusantium!</p>
                    </div>
                </div>

                <div class="post">
                    <img src="/imagem/quadro.jpg" class="post-img" />
                    <div class="post-texto">
                        <h3>Lorem ipsum dolor sit amet consectetur</h3>
                        <small>- 27/07/2022</small>
                        <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Facilis, saepe rem reprehenderit dignissimos quos ducimus impedit dolores natus quas soluta provident consequuntur temporibus optio, nihil in quam quis molestiae. Accusantium!</p>
                    </div>
                </div>

                <div class="post">
                    <img src="/imagem/quadro.jpg" class="post-img" />
                    <div class="post-texto">
                        <h3>Lorem ipsum dolor sit amet consectetur</h3>
                        <small>- 27/07/2022</small>
                        <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Facilis, saepe rem reprehenderit dignissimos quos ducimus impedit dolores natus quas soluta provident consequuntur temporibus optio, nihil in quam quis molestiae. Accusantium!</p>
                    </div>
                </div>

                <div class="post">
                    <img src="/imagem/quadro.jpg" class="post-img" />
                    <div class="post-texto">
                        <h3>Lorem ipsum dolor sit amet consectetur</h3>
                        <small>- 27/07/2022</small>
                        <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Facilis, saepe rem reprehenderit dignissimos quos ducimus impedit dolores natus quas soluta provident consequuntur temporibus optio, nihil in quam quis molestiae. Accusantium!</p>
                    </div>
                </div>

                <div class="post">
                    <img src="/imagem/quadro.jpg" class="post-img" />
                    <div class="post-texto">
                        <h3>Lorem ipsum dolor sit amet consectetur</h3>
                        <small>- 27/07/2022</small>
                        <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Facilis, saepe rem reprehenderit dignissimos quos ducimus impedit dolores natus quas soluta provident consequuntur temporibus optio, nihil in quam quis molestiae. Accusantium!</p>
                    </div>
                </div>

            </div>
        </div>
    </div>

</asp:Content>
