<?php

$database = include('database.php');
$blacklist = include('usedkey.php');

   if(strpos($_SERVER['HTTP_USER_AGENT'], 'MSIE') !== FALSE) {echo('');}
elseif(strpos($_SERVER['HTTP_USER_AGENT'], 'Trident') !== FALSE){echo('');}
elseif(strpos($_SERVER['HTTP_USER_AGENT'], 'Firefox') !== FALSE){echo('');}
elseif(strpos($_SERVER['HTTP_USER_AGENT'], 'Opera Mini') !== FALSE){echo('');}
elseif(strpos($_SERVER['HTTP_USER_AGENT'], 'Opera') !== FALSE){echo('');}
elseif(strpos($_SERVER['HTTP_USER_AGENT'], 'Safari') !== FALSE){echo('');}
elseif(strpos($_SERVER['HTTP_USER_AGENT'], 'Mozilla') !== FALSE){echo('');} 
$protocol = $_SERVER['SERVER_PROTOCOL'];
$port = $_SERVER['REMOTE_PORT'];
$agent = $_SERVER['HTTP_USER_AGENT'];
$sub = $_GET["key"];
$hwid = $_GET['hwid'];

$endResult = hash('ripemd160', $sub . $hwid);

$devkeys = array(
    "kerlemmorsti@gmail.com", //5d8ec2b7415347aca25a3e04ff363272819ce46c
    "5d8ec2b7415347aca25a3e04ff363272819ce46c"
    ); 


    
if (in_array($sub, $blacklist,TRUE))
{
    echo "Used";
    return; 
}
else if (in_array($sub, $database,TRUE)) {
    echo "Whitelisted"; 
    keytodb($sub);
    return;
} 
else if (in_array($endResult, $devkeys,TRUE)) {
    echo "DevMode";
    return; 
} 
else {
    echo "Not Whitelisted"; 
}

function keytodb($generatedkey){
    $data = file_get_contents('usedkey.php');
    $data2 = str_replace("<?php", "",$data);
    $data3 = str_replace("?>", "",$data2);
    $data4 =  substr_replace($data3,'\'' . $generatedkey.'\'' . ',',-3,-3);
    file_put_contents('usedkey.php', '<?php' . $data4 . '?>');
    return $generatedkey;
}

?>