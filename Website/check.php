<?php

$database = include('database.php');
$blacklist = include('usedkey.php');

$agent = $_SERVER['HTTP_USER_AGENT'];
if(strpos($agent, 'MSIE') !== FALSE || strpos($agent, 'Trident') !== FALSE || strpos($agent, 'Firefox') !== FALSE || strpos($agent, 'Opera Mini') !== FALSE || strpos($agent, 'Opera') !== FALSE || strpos($agent, 'Safari') !== FALSE || strpos($agent, 'Mozilla') !== FALSE) {die('nope');}
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
