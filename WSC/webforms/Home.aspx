<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WSC.webforms.Home" %>

<!DOCTYPE HTML>
<!--
	Aesthetic by gettemplates.co
	Twitter: http://twitter.com/gettemplateco
	URL: http://gettemplates.co
-->
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
							<li><a href="Login.aspx"><i><asp:Label Visible="false" runat="server" ID="LoginLbl">Login</asp:Label></i></a></li>
                            <li><i><asp:Label runat="server" ID="welcomelbl" Visible="false"></asp:Label></i></></li>
                            <li><i><asp:Button ID="Logoutbtn" OnClick="Logoutbtn_Click" CssClass="btn btn-primary" runat="server" Text="Logout" Visible="true"/></i></></li>
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
                            <li><asp:Button ID="btnCustomerArea" OnClick="btnCustomerArea_Click" CssClass="btn btn-primary" runat="server" Text="Customer Area" Visible="false"/></li>
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
					<h1>We are a<strong> Printing & Engraving Company</strong></h1>	
					<h2>Far far away, behind the mountains on the hills of valhala.</h2>
					<div class="text-center"><a href="Login.aspx" class="btn btn-primary">Login Here</a></div>
				</div>
			</div>
		</div>
	</header>

	<div class="flex-section gtco-gray-bg">
		<div class="col-1">
			<div class="text">

				<div class="row row-pb-sm">
					<div class="col-md-12">
					<h2>Printing Is our Business</h2>
					
					<p>WSC Printing and Engraving has serviced professional, service firms and companies of all sizes for their printing needs. We have worked with mid-size companies as well as Fortune 500 organizations in Chicago, nationally and internationally.
Our unique blend of printing and engraving capabilities, production expertise and creative problem solving will assist you in enhancing your brand while providing innovative & cost-efficient solutions for your purchasing and marketing departments.</p>
					</div>
				</div>
			</div>
		</div>
		<div class="col-2 flex-img" style="background-image: url(../images/img_1.jpg);"></div>
	</div>
	
	<div class="gtco-cover gtco-cover-sm" style="background-image: url(../images/img_bg_2.jpg)"  data-stellar-background-ratio="0.5">
		<div class="overlay"></div>
		<div class="gtco-container text-center">
			<div class="display-t">
				<div class="display-tc">
					<h1 class="animate-box">Experts in Practice</h1>
				</div>	
			</div>
		</div>
	</div>

	<div class="flex-section reverse">
		<div class="col-1">
			<div class="text">

				<div class="row row-pb-sm">
					<div class="col-md-12">
						<h2>Expertise &amp; Beliefs</h2>
						<p>WSC Printing & Engraving has been a premier source for a variety of commercial and trade printing needs since 1921. Commercial offset printing, digital printing, raised printing, foil stamping, blind embossing, and engraving are services we offer to complete your projects. We offer a personalized online ordering system exclusively for your company that can be tailored specifically to your business needs. We can recommend the optimal stock for your project as well as the best process to enhance your design. Our Sales staff, customer service representatives, and production staff have high-quality control standards to ensure that your project will pass inspection before you receive it. We specialize in custom orders but can also handle large production orders with our varied services.</p>					
                	</div>
				</div>				
			</div>
		</div>
		<div class="col-2 flex-img" style="background-image: url(../images/img_bg_2.jpg);"></div>
	</div>

	<div class="gtco-cover gtco-cover-sm" style="background-image: url(../images/img_bg_3.jpg)" data-stellar-background-ratio="0.5">
		<div class="overlay"></div>
		<div class="gtco-container text-center">
			<div class="display-t">
				<div class="display-tc">
					<h1 class="animate-box">Quality Over Quantity</h1>
				</div>	
			</div>
		</div>
	</div>
	
	<div class="overflow-hid"> 
		<div class="gtco-section">
			<div class="gtco-container">
				<div class="row">
					<div class="col-md-8 col-md-offset-2 text-center gtco-heading">
						<h2>Catelog</h2>
						<p>We offer the best engraving and printing services available in the market! see our available products below.</p>
					</div>
				</div>
				<div class="row">

					<div class="col-lg-4 col-md-4 col-sm-6">
						<a href="#" class="gtco-card-item">
							<figure>
								<div class="overlay"><i class="ti-plus"></i></div>
								<img src="../images/visor.png" alt="Image" class="img-responsive">
							</figure>
							<div class="gtco-text">
								<h2>Visor</h2>
								<p>Made by bohemian visors inc, best quality visors for fraction of the price.</p>
								<p><asp:Button runat="server" CssClass="btn btn-primary" id="Visor" Text="Order Now" OnClick="btnAddToOrder_Click"/></p>
							</div>
						</a>
					</div>
					<div class="col-lg-4 col-md-4 col-sm-6">
						<a href="#" class="gtco-card-item">
							<figure>
								<div class="overlay"><i class="ti-plus"></i></div>
								<img src="../images/smallgoldplaque.png" alt="Image" class="img-responsive">
							</figure>
							<div class="gtco-text">
								<h2>Small Gold Plaque</h2>
								<p>Gold Plaque, created by the Gods themselves.</p>
								<p><asp:Button runat="server" CssClass="btn btn-primary" id="Small_Gold_Plaque" Text="Order Now" OnClick="btnAddToOrder_Click"/></p>
							</div>
						</a>
					</div>
					<div class="col-lg-4 col-md-4 col-sm-6">
						<a href="#" class="gtco-card-item">
							<figure>
								<div class="overlay"><i class="ti-plus"></i></div>
								<img src="../images/smallsilverplaque.jpg" alt="Image" class="img-responsive">
							</figure>
							<div class="gtco-text">
								<h2>Small Silver Plaque</h2>
								<p>1 1/4 x 2 3/4 Oval Nickel Silver Plate</p>
								<p><asp:Button runat="server" CssClass="btn btn-primary" id="Small_Silver_Plaque" Text="Order Now" OnClick="btnAddToOrder_Click"/></p>
							</div>
						</a>
					</div>
				</div>
			</div>
		</div>
		
		<div id="gtco-features">
		</div>
	</div>


	<div class="gtco-cover gtco-cover-sm" style="background-image: url(../images/img_bg_1.jpg)"  data-stellar-background-ratio="0.5">
		<div class="overlay"></div>
		<div class="gtco-container text-center">
			<div class="display-t">
				<div class="display-tc">
					<h1>We have high quality services that you will surely love!</h1>
				</div>	
			</div>
		</div>
	</div>

	<div id="gtco-counter" class="gtco-section">
		<div class="gtco-container">

			<div class="row">
				<div class="col-md-8 col-md-offset-2 text-center gtco-heading animate-box">
					<h2>Facts</h2>
					<p>At WSC we take pride in what we do and we have facts to back it up.</p>
				</div>
			</div>

			<div class="row">
				
				<div class="col-md-3 col-sm-6 animate-box" data-animate-effect="fadeInUp">
					<div class="feature-center">
						<span class="counter js-counter" data-from="0" data-to="196" data-speed="5000" data-refresh-interval="50">1</span>
						<span class="counter-label">Clients</span>

					</div>
				</div>
				<div class="col-md-3 col-sm-6 animate-box" data-animate-effect="fadeInUp">
					<div class="feature-center">
						<span class="counter js-counter" data-from="0" data-to="97" data-speed="5000" data-refresh-interval="50">1</span>
						<span class="counter-label">Projects</span>
					</div>
				</div>
				<div class="col-md-3 col-sm-6 animate-box" data-animate-effect="fadeInUp">
					<div class="feature-center">
						<span class="counter js-counter" data-from="0" data-to="12402" data-speed="5000" data-refresh-interval="50">1</span>
						<span class="counter-label">Coffee</span>
					</div>
				</div>
				<div class="col-md-3 col-sm-6 animate-box" data-animate-effect="fadeInUp">
					<div class="feature-center">
						<span class="counter js-counter" data-from="0" data-to="12202" data-speed="5000" data-refresh-interval="50">1</span>
						<span class="counter-label">Printing & Engraving Jobs</span>

					</div>
				</div>
					
			</div>
		</div>
	</div>

		<footer id="gtco-footer" role="contentinfo">
		<div class="gtco-container">
			<div class="row row-p	b-md">

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

			<div class="row copyright">
				<div class="col-md-12">
					<p class="pull-left">
						<small class="block">Designed by Seal Team 7</small>
					</p>
					<p class="pull-right">
						<ul class="gtco-social-icons pull-right">
							<li><a href="#"><i class="icon-twitter"></i></a></li>
							<li><a href="#"><i class="icon-facebook"></i></a></li>
							<li><a href="#"><i class="icon-linkedin"></i></a></li>
							<li><a href="#"><i class="icon-dribbble"></i></a></li>
						</ul>
					</p>
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


