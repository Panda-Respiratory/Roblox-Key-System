<?php

$database = include('database.php');
$blacklist = include('usedkey.php');

$agent = $_SERVER['HTTP_USER_AGENT'];
if(strpos($agent, 'MSIE') !== FALSE || strpos($agent, 'Trident') !== FALSE || strpos($agent, 'Firefox') !== FALSE || strpos($agent, 'Opera Mini') !== FALSE || strpos($agent, 'Opera') !== FALSE || strpos($agent, 'Safari') !== FALSE || strpos($agent, 'Mozilla') !== FALSE) {die('nope');}
$sub = $_GET["key"];

if (in_array($sub, $blacklist,TRUE))
{
    echo "Used";
    return; 
}
if (in_array($sub, $database,TRUE)) {
    echo "Whitelisted"; 
    keytodb($sub);
} else {
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
