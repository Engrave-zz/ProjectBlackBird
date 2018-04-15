<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Confirmation.aspx.cs" Inherits="WSC.webforms.Confirmation" %>

<!DOCTYPE HTML>
<html>
	<head>
	<meta charset="utf-8">
	<meta http-equiv="X-UA-Compatible" content="IE=edge">
	<title>WSC</title>

  	<!-- Facebook and Twitter integration -->
	<meta property="og:title" content=""/>
	<meta property="og:image" content=""/>
	<meta property="og:url" content=""/>
	<meta property="og:site_name" content=""/>
	<meta property="og:description" content=""/>
	<meta name="twitter:title" content="" />
	<meta name="twitter:image" content="" />
	<meta name="twitter:url" content="" />
	<meta name="twitter:card" content="" />

	<link href="https://fonts.googleapis.com/css?family=Open+Sans:300,400,700" rel="stylesheet">
	
	<!-- Animate.css -->
	<link rel="stylesheet" href="../css/animate.css">
	<!-- Icomoon Icon Fonts-->
	<link rel="stylesheet" href="../css/icomoon.css">
	<!-- Themify Icons-->
	<link rel="stylesheet" href="../css/themify-icons.css">
	<!-- Bootstrap  -->
	<link rel="stylesheet" href="../css/bootstrap.css">

	<!-- Magnific Popup -->
	<link rel="stylesheet" href="../css/magnific-popup.css">
  
	<!-- Owl Carousel  -->
	<link rel="stylesheet" href="../css/owl.carousel.min.css">
	<link rel="stylesheet" href="../css/owl.theme.default.min.css">

	<!-- Theme style  -->
	<link rel="stylesheet" href="../css/style.css">

	<!-- Modernizr JS -->
	<script src="../js/modernizr-2.6.2.min.js"></script>
	<!-- FOR IE9 below -->
	<!--[if lt IE 9]>
	<script src="js/respond.min.js"></script>
	<![endif]-->

	</head>
	<body>
	<form runat="server">
	<div class="gtco-loader"></div>
	
	<div id="page">

	
	<div class="page-inner">

	<div id="head-top" style="position: absolute; width: 100%; top: 0; ">
		<div class="gtco-top">
			<div class="container-fluid">
				<div class="row">
					<div class="col-md-6 col-xs-6">
						<div id="gtco-logo"><a href="Home.aspx">WSC<em>.</em></a></div>
					</div>
					<div class="col-md-6 col-xs-6 social-icons">
						<ul class="gtco-social-top">
							<li>
                                <a href="Login.aspx"><i><asp:Label runat="server" ID="LoginLbl">Login</asp:Label></i></a>
							</li>
						</ul>
					</div>
				</div>
			</div>	
		</div>
		<nav class="gtco-nav sticky-banner" role="navigation">
			<div class="gtco-container">
				
				<div class="row">
					<div class="col-xs-12 text-center menu-1">
						<ul>
							<li class="active"><a href="Home.aspx">Home</a></li>
						</ul>
					</div>
				</div>
				
			</div>
		</nav>
	</div>
	
	<header id="gtco-header" class="gtco-cover gtco-cover-md" role="banner" style="background-image: url(../images/img_bg_4.jpg)" data-stellar-background-ratio="0.5">
		<div class="overlay"></div>
		<div class="gtco-container">
			<div class="row row-mt-15em">
				<div class="col-md-12 mt-text text-center animate-box" data-animate-effect="fadeInUp">
                    <h1><strong>Confirmation</strong></h1>	
					<h2>Please see your confirmation details below, if you see any failures please contact helpdesk. Press confirm to return to Login Page.</h2>
                    <h2><strong><asp:Label ID="lblConfirm" CssClass="col-md-8 col-md-offset-2 text-center gtco-heading" runat="server" Visible="true"></asp:Label></strong></h2>
				    <div class="text-center">
                     <asp:Button ID="btnConfirm" OnClick="btnConfirm_Click" runat="server" CssClass="btn btn-primary" Text="Confirm" />
				    </div>
                </div>
                <div class="col-md-12 mt-text text-center animate-box" data-animate-effect="fadeInUp">
                        <asp:Label ID="txtError" runat="server" Visible="false"></asp:Label>
                </div>
			</div>
		</div>
	</header>

	<footer id="gtco-footer" role="contentinfo">
		<div class="gtco-container">
			<div class="row row-p	b-md">

				<div class="col-md-4">
					<div class="gtco-widget">
						<h3>About Us</h3>
						<p>Werner Printing & Engraving Co. is proud to be an independent, third generation family owned business.  Located in Chicago’s thriving West Loop, Werner Printing & Engraving is one of Midwest’s leading manufacturers of printed and engraved materials.  If your project calls for offset printing, embossing, engraving or any of our other print processes, we handle in-house to maintain quality control.</p>
					</div>
				</div>

				<div class="col-md-4">
					<div class="gtco-widget">
						<h3>About Us</h3>
						<p>WSC Printing & Engraving. is proud to be an independent, third generation family owned business.  Located in Chicago’s thriving West Loop, Werner Printing & Engraving is one of Midwest’s leading manufacturers of printed and engraved materials.  If your project calls for offset printing, embossing, engraving or any of our other print processes, we handle in-house to maintain quality control.</p>
					</div>
				</div>

				<div class="col-md-4 col-md-push-1">
					<div class="gtco-widget">
						<h3>Services</h3>
						<ul class="gtco-footer-links">
							<li>Printing</li>
							<li>Engraving</li>
							<li>Design</li>
						</ul>
					</div>
				</div>

				

				<div class="col-md-3 col-md-push-1">
					<div class="gtco-widget">
						<h3>Get In Touch</h3>
						<ul class="gtco-quick-contact">
							<li><a href="#"><i class="icon-phone"></i> +1 234 567 890</a></li>
							<li><a href="#"><i class="icon-mail2"></i> info@wsc.co</a></li>
							<li><a href="#"><i class="icon-chat"></i> Live Chat</a></li>
						</ul>
					</div>
				</div>

		</div>
	</footer>
	</div>

	</div>

	<div class="gototop js-top">
		<a href="#" class="js-gotop"><i class="icon-arrow-up"></i></a>
	</div>
	
	<!-- jQuery -->
	<script src="../js/jquery.min.js"></script>
	<!-- jQuery Easing -->
	<script src="../js/jquery.easing.1.3.js"></script>
	<!-- Bootstrap -->
	<script src="../js/bootstrap.min.js"></script>
	<!-- Waypoints -->
	<script src="../js/jquery.waypoints.min.js"></script>
	<script src="../js/sticky.js"></script>
	<!-- Carousel -->
	<script src="../js/owl.carousel.min.js"></script>
	<!-- countTo -->
	<script src="../js/jquery.countTo.js"></script>

	<!-- Stellar Parallax -->
	<script src="../js/jquery.stellar.min.js"></script>

	<!-- Magnific Popup -->
	<script src="../js/jquery.magnific-popup.min.js"></script>
	<script src="../js/magnific-popup-options.js"></script>
	
	<!-- Main -->
	<script src="../js/main.js"></script>
    </form>
	</body>
    </html>