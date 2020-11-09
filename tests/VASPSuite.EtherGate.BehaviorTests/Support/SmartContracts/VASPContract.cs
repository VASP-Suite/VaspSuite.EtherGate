using System.Threading.Tasks;
using Nethereum.Hex.HexTypes;
using Nethereum.Web3;

namespace VASPSuite.EtherGate.BehaviorTests.Support.SmartContracts
{
    public class VASPContract : SmartContract
    {
        public const string ABI = @"[{""inputs"":[{""internalType"":""bytes4"",""name"":""vaspCode"",""type"":""bytes4""},{""internalType"":""address"",""name"":""owner"",""type"":""address""},{""internalType"":""bytes4"",""name"":""channels"",""type"":""bytes4""},{""internalType"":""bytes"",""name"":""transportKey"",""type"":""bytes""},{""internalType"":""bytes"",""name"":""messageKey"",""type"":""bytes""},{""internalType"":""bytes"",""name"":""signingKey"",""type"":""bytes""}],""stateMutability"":""nonpayable"",""type"":""constructor""},{""anonymous"":false,""inputs"":[{""indexed"":true,""internalType"":""bytes4"",""name"":""vaspCode"",""type"":""bytes4""},{""indexed"":false,""internalType"":""bytes4"",""name"":""previousChannels"",""type"":""bytes4""},{""indexed"":false,""internalType"":""bytes4"",""name"":""newChannels"",""type"":""bytes4""}],""name"":""ChannelsChanged"",""type"":""event""},{""anonymous"":false,""inputs"":[{""indexed"":true,""internalType"":""bytes4"",""name"":""vaspCode"",""type"":""bytes4""},{""indexed"":false,""internalType"":""bytes"",""name"":""previousMessageKey"",""type"":""bytes""},{""indexed"":false,""internalType"":""bytes"",""name"":""newMessageKey"",""type"":""bytes""}],""name"":""MessageKeyChanged"",""type"":""event""},{""anonymous"":false,""inputs"":[],""name"":""OwnerRoleTransferCancelled"",""type"":""event""},{""anonymous"":false,""inputs"":[{""indexed"":true,""internalType"":""address"",""name"":""previousOwner"",""type"":""address""},{""indexed"":true,""internalType"":""address"",""name"":""newOwner"",""type"":""address""}],""name"":""OwnerRoleTransferCompleted"",""type"":""event""},{""anonymous"":false,""inputs"":[{""indexed"":true,""internalType"":""address"",""name"":""currentOwner"",""type"":""address""},{""indexed"":true,""internalType"":""address"",""name"":""newOwnerCandidate"",""type"":""address""}],""name"":""OwnerRoleTransferStarted"",""type"":""event""},{""anonymous"":false,""inputs"":[{""indexed"":true,""internalType"":""bytes32"",""name"":""role"",""type"":""bytes32""},{""indexed"":true,""internalType"":""address"",""name"":""account"",""type"":""address""},{""indexed"":true,""internalType"":""address"",""name"":""sender"",""type"":""address""}],""name"":""RoleGranted"",""type"":""event""},{""anonymous"":false,""inputs"":[{""indexed"":true,""internalType"":""bytes32"",""name"":""role"",""type"":""bytes32""},{""indexed"":true,""internalType"":""address"",""name"":""account"",""type"":""address""},{""indexed"":true,""internalType"":""address"",""name"":""sender"",""type"":""address""}],""name"":""RoleRevoked"",""type"":""event""},{""anonymous"":false,""inputs"":[{""indexed"":true,""internalType"":""bytes4"",""name"":""vaspCode"",""type"":""bytes4""},{""indexed"":false,""internalType"":""bytes"",""name"":""previousSigningKey"",""type"":""bytes""},{""indexed"":false,""internalType"":""bytes"",""name"":""newSigningKey"",""type"":""bytes""}],""name"":""SigningKeyChanged"",""type"":""event""},{""anonymous"":false,""inputs"":[{""indexed"":true,""internalType"":""bytes4"",""name"":""vaspCode"",""type"":""bytes4""},{""indexed"":false,""internalType"":""bytes"",""name"":""previousTransportKey"",""type"":""bytes""},{""indexed"":false,""internalType"":""bytes"",""name"":""newTransportKey"",""type"":""bytes""}],""name"":""TransportKeyChanged"",""type"":""event""},{""inputs"":[],""name"":""DEFAULT_ADMIN_ROLE"",""outputs"":[{""internalType"":""bytes32"",""name"":"""",""type"":""bytes32""}],""stateMutability"":""view"",""type"":""function""},{""inputs"":[],""name"":""OWNER_ROLE"",""outputs"":[{""internalType"":""bytes32"",""name"":"""",""type"":""bytes32""}],""stateMutability"":""view"",""type"":""function""},{""inputs"":[],""name"":""acceptOwnerRole"",""outputs"":[],""stateMutability"":""nonpayable"",""type"":""function""},{""inputs"":[],""name"":""cancelOwnerRoleTransfer"",""outputs"":[],""stateMutability"":""nonpayable"",""type"":""function""},{""inputs"":[],""name"":""channels"",""outputs"":[{""internalType"":""bytes4"",""name"":"""",""type"":""bytes4""}],""stateMutability"":""view"",""type"":""function""},{""inputs"":[{""internalType"":""bytes32"",""name"":""role"",""type"":""bytes32""}],""name"":""getRoleAdmin"",""outputs"":[{""internalType"":""bytes32"",""name"":"""",""type"":""bytes32""}],""stateMutability"":""view"",""type"":""function""},{""inputs"":[{""internalType"":""bytes32"",""name"":""role"",""type"":""bytes32""},{""internalType"":""uint256"",""name"":""index"",""type"":""uint256""}],""name"":""getRoleMember"",""outputs"":[{""internalType"":""address"",""name"":"""",""type"":""address""}],""stateMutability"":""view"",""type"":""function""},{""inputs"":[{""internalType"":""bytes32"",""name"":""role"",""type"":""bytes32""}],""name"":""getRoleMemberCount"",""outputs"":[{""internalType"":""uint256"",""name"":"""",""type"":""uint256""}],""stateMutability"":""view"",""type"":""function""},{""inputs"":[{""internalType"":""bytes32"",""name"":""role"",""type"":""bytes32""},{""internalType"":""address"",""name"":""account"",""type"":""address""}],""name"":""grantRole"",""outputs"":[],""stateMutability"":""nonpayable"",""type"":""function""},{""inputs"":[{""internalType"":""bytes32"",""name"":""role"",""type"":""bytes32""},{""internalType"":""address"",""name"":""account"",""type"":""address""}],""name"":""hasRole"",""outputs"":[{""internalType"":""bool"",""name"":"""",""type"":""bool""}],""stateMutability"":""view"",""type"":""function""},{""inputs"":[],""name"":""messageKey"",""outputs"":[{""internalType"":""bytes"",""name"":"""",""type"":""bytes""}],""stateMutability"":""view"",""type"":""function""},{""inputs"":[],""name"":""renounceOwnerRole"",""outputs"":[],""stateMutability"":""nonpayable"",""type"":""function""},{""inputs"":[{""internalType"":""bytes32"",""name"":""role"",""type"":""bytes32""},{""internalType"":""address"",""name"":""account"",""type"":""address""}],""name"":""renounceRole"",""outputs"":[],""stateMutability"":""nonpayable"",""type"":""function""},{""inputs"":[{""internalType"":""bytes32"",""name"":""role"",""type"":""bytes32""},{""internalType"":""address"",""name"":""account"",""type"":""address""}],""name"":""revokeRole"",""outputs"":[],""stateMutability"":""nonpayable"",""type"":""function""},{""inputs"":[{""internalType"":""bytes4"",""name"":""newChannels"",""type"":""bytes4""}],""name"":""setChannels"",""outputs"":[],""stateMutability"":""nonpayable"",""type"":""function""},{""inputs"":[{""internalType"":""bytes"",""name"":""newMessageKey"",""type"":""bytes""}],""name"":""setMessageKey"",""outputs"":[],""stateMutability"":""nonpayable"",""type"":""function""},{""inputs"":[{""internalType"":""bytes"",""name"":""newSigningKey"",""type"":""bytes""}],""name"":""setSigningKey"",""outputs"":[],""stateMutability"":""nonpayable"",""type"":""function""},{""inputs"":[{""internalType"":""bytes"",""name"":""newTransportKey"",""type"":""bytes""}],""name"":""setTransportKey"",""outputs"":[],""stateMutability"":""nonpayable"",""type"":""function""},{""inputs"":[],""name"":""signingKey"",""outputs"":[{""internalType"":""bytes"",""name"":"""",""type"":""bytes""}],""stateMutability"":""view"",""type"":""function""},{""inputs"":[{""internalType"":""address"",""name"":""newOwnerCandidate"",""type"":""address""}],""name"":""transferOwnerRole"",""outputs"":[],""stateMutability"":""nonpayable"",""type"":""function""},{""inputs"":[],""name"":""transportKey"",""outputs"":[{""internalType"":""bytes"",""name"":"""",""type"":""bytes""}],""stateMutability"":""view"",""type"":""function""},{""inputs"":[],""name"":""vaspCode"",""outputs"":[{""internalType"":""bytes4"",""name"":"""",""type"":""bytes4""}],""stateMutability"":""view"",""type"":""function""}]";
        public const string ByteCode = @"0x60806040523480156200001157600080fd5b506040516200386b3803806200386b833981810160405260c08110156200003757600080fd5b81019080805190602001909291908051906020019092919080519060200190929190805160405193929190846401000000008211156200007657600080fd5b838201915060208201858111156200008d57600080fd5b8251866001820283011164010000000082111715620000ab57600080fd5b8083526020830192505050908051906020019080838360005b83811015620000e1578082015181840152602081019050620000c4565b50505050905090810190601f1680156200010f5780820380516001836020036101000a031916815260200191505b50604052602001805160405193929190846401000000008211156200013357600080fd5b838201915060208201858111156200014a57600080fd5b82518660018202830111640100000000821117156200016857600080fd5b8083526020830192505050908051906020019080838360005b838110156200019e57808201518184015260208101905062000181565b50505050905090810190601f168015620001cc5780820380516001836020036101000a031916815260200191505b5060405260200180516040519392919084640100000000821115620001f057600080fd5b838201915060208201858111156200020757600080fd5b82518660018202830111640100000000821117156200022557600080fd5b8083526020830192505050908051906020019080838360005b838110156200025b5780820151818401526020810190506200023e565b50505050905090810190601f168015620002895780820380516001836020036101000a031916815260200191505b5060405250505084600073ffffffffffffffffffffffffffffffffffffffff168173ffffffffffffffffffffffffffffffffffffffff16141562000319576040517f08c379a0000000000000000000000000000000000000000000000000000000008152600401808060200182810382526024815260200180620038476024913960400191505060405180910390fd5b6200034b7fb19546dff01e856fb3f010c267a7b1c60363cf8a4664e21cc89c26224620214e82620005dd60201b60201c565b6200037d7fb19546dff01e856fb3f010c267a7b1c60363cf8a4664e21cc89c26224620214e80620005f360201b60201c565b50600060e01b7bffffffffffffffffffffffffffffffffffffffffffffffffffffffff1916867bffffffffffffffffffffffffffffffffffffffffffffffffffffffff1916141562000437576040517f08c379a000000000000000000000000000000000000000000000000000000000815260040180806020018281038252601f8152602001807f56415350436f6e74726163743a2076617370436f646520697320656d7074790081525060200191505060405180910390fd5b62000448836200061160201b60201c565b6200049f576040517f08c379a0000000000000000000000000000000000000000000000000000000008152600401808060200182810382526025815260200180620037dc6025913960400191505060405180910390fd5b620004b0826200061160201b60201c565b62000507576040517f08c379a0000000000000000000000000000000000000000000000000000000008152600401808060200182810382526023815260200180620038246023913960400191505060405180910390fd5b62000518816200061160201b60201c565b6200056f576040517f08c379a0000000000000000000000000000000000000000000000000000000008152600401808060200182810382526023815260200180620038016023913960400191505060405180910390fd5b85600560006101000a81548163ffffffff021916908360e01c02179055506200059e84620006b260201b60201c565b620005af83620007e460201b60201c565b620005c08262000a1460201b60201c565b620005d18162000c4460201b60201c565b505050505050620010b6565b620005ef828262000e7460201b60201c565b5050565b80600080848152602001908152602001600020600201819055505050565b600060218251148015620006ab5750600260f81b826000815181106200063357fe5b602001015160f81c60f81b7effffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff19161480620006aa5750600360f81b826000815181106200067b57fe5b602001015160f81c60f81b7effffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff1916145b5b9050919050565b807bffffffffffffffffffffffffffffffffffffffffffffffffffffffff1916600160149054906101000a900460e01b7bffffffffffffffffffffffffffffffffffffffffffffffffffffffff191614620007e157600560009054906101000a900460e01b7bffffffffffffffffffffffffffffffffffffffffffffffffffffffff19167f4750a47067e046fac31480e0b4e2cae9612447cf7627188a1e6ca15a15f68dad600160149054906101000a900460e01b8360405180837bffffffffffffffffffffffffffffffffffffffffffffffffffffffff19168152602001827bffffffffffffffffffffffffffffffffffffffffffffffffffffffff191681526020019250505060405180910390a280600160146101000a81548163ffffffff021916908360e01c02179055505b50565b6200089460028054600181600116156101000203166002900480601f016020809104026020016040519081016040528092919081815260200182805460018160011615610100020316600290048015620008825780601f10620008565761010080835404028352916020019162000882565b820191906000526020600020905b8154815290600101906020018083116200086457829003601f168201915b50505050508262000f1760201b60201c565b1562000a1157600560009054906101000a900460e01b7bffffffffffffffffffffffffffffffffffffffffffffffffffffffff19167f5c96fb34ed318f1d939bea5d00d59bca36271387847cbcfeb26662013ec937a66002836040518080602001806020018381038352858181546001816001161561010002031660029004815260200191508054600181600116156101000203166002900480156200097e5780601f1062000952576101008083540402835291602001916200097e565b820191906000526020600020905b8154815290600101906020018083116200096057829003601f168201915b5050838103825284818151815260200191508051906020019080838360005b83811015620009ba5780820151818401526020810190506200099d565b50505050905090810190601f168015620009e85780820380516001836020036101000a031916815260200191505b5094505050505060405180910390a2806002908051906020019062000a0f92919062001010565b505b50565b62000ac460038054600181600116156101000203166002900480601f01602080910402602001604051908101604052809291908181526020018280546001816001161561010002031660029004801562000ab25780601f1062000a865761010080835404028352916020019162000ab2565b820191906000526020600020905b81548152906001019060200180831162000a9457829003601f168201915b50505050508262000f1760201b60201c565b1562000c4157600560009054906101000a900460e01b7bffffffffffffffffffffffffffffffffffffffffffffffffffffffff19167f950f942383e7d5e469f9efa063df3d5af93dc7a7108c2039418309840e2d6b0f60038360405180806020018060200183810383528581815460018160011615610100020316600290048152602001915080546001816001161561010002031660029004801562000bae5780601f1062000b825761010080835404028352916020019162000bae565b820191906000526020600020905b81548152906001019060200180831162000b9057829003601f168201915b5050838103825284818151815260200191508051906020019080838360005b8381101562000bea57808201518184015260208101905062000bcd565b50505050905090810190601f16801562000c185780820380516001836020036101000a031916815260200191505b5094505050505060405180910390a2806003908051906020019062000c3f92919062001010565b505b50565b62000cf460048054600181600116156101000203166002900480601f01602080910402602001604051908101604052809291908181526020018280546001816001161561010002031660029004801562000ce25780601f1062000cb65761010080835404028352916020019162000ce2565b820191906000526020600020905b81548152906001019060200180831162000cc457829003601f168201915b50505050508262000f1760201b60201c565b1562000e7157600560009054906101000a900460e01b7bffffffffffffffffffffffffffffffffffffffffffffffffffffffff19167faa96f2fda75fa7cf89d9d618a482d7e9345538c3c92aae6534a77f22b5b16b0660048360405180806020018060200183810383528581815460018160011615610100020316600290048152602001915080546001816001161561010002031660029004801562000dde5780601f1062000db25761010080835404028352916020019162000dde565b820191906000526020600020905b81548152906001019060200180831162000dc057829003601f168201915b5050838103825284818151815260200191508051906020019080838360005b8381101562000e1a57808201518184015260208101905062000dfd565b50505050905090810190601f16801562000e485780820380516001836020036101000a031916815260200191505b5094505050505060405180910390a2806004908051906020019062000e6f92919062001010565b505b50565b62000ea28160008085815260200190815260200160002060000162000f3360201b620017331790919060201c565b1562000f135762000eb862000f6b60201b60201c565b73ffffffffffffffffffffffffffffffffffffffff168173ffffffffffffffffffffffffffffffffffffffff16837f2f8788117e7eff1d82e926ec794901d17c78024a50270940304540a733656f0d60405160405180910390a45b5050565b6000818051906020012083805190602001201415905092915050565b600062000f63836000018373ffffffffffffffffffffffffffffffffffffffff1660001b62000f7360201b60201c565b905092915050565b600033905090565b600062000f87838362000fed60201b60201c565b62000fe257826000018290806001815401808255809150506001900390600052602060002001600090919091909150558260000180549050836001016000848152602001908152602001600020819055506001905062000fe7565b600090505b92915050565b600080836001016000848152602001908152602001600020541415905092915050565b828054600181600116156101000203166002900490600052602060002090601f016020900481019282601f106200105357805160ff191683800117855562001084565b8280016001018555821562001084579182015b828111156200108357825182559160200191906001019062001066565b5b50905062001093919062001097565b5090565b5b80821115620010b257600081600090555060010162001098565b5090565b61271680620010c66000396000f3fe608060405234801561001057600080fd5b50600436106101425760003560e01c80639010d07c116100b8578063c823bdc51161007c578063c823bdc5146105e6578063ca15c87314610669578063d547741f146106ab578063e58378bb146106f9578063ecfd616d14610717578063ed7c1b201461079057610142565b80639010d07c146104ab57806391d148541461050d578063a217fddf14610571578063ae3a2d7e1461058f578063c76020b3146105dc57610142565b80635566e2801161010a5780635566e2801461026c57806358221c6b1461027657806366f27fd3146102f95780636dc004da1461037c57806379a4e450146103f55780638c5970201461043257610142565b806307c4b96714610147578063248a9ca3146101845780632e85977a146101c65780632f2ff15d146101d057806336568abe1461021e575b600080fd5b61014f6107d4565b60405180827bffffffffffffffffffffffffffffffffffffffffffffffffffffffff1916815260200191505060405180910390f35b6101b06004803603602081101561019a57600080fd5b81019080803590602001909291905050506107eb565b6040518082815260200191505060405180910390f35b6101ce61080a565b005b61021c600480360360408110156101e657600080fd5b8101908080359060200190929190803573ffffffffffffffffffffffffffffffffffffffff169060200190929190505050610845565b005b61026a6004803603604081101561023457600080fd5b8101908080359060200190929190803573ffffffffffffffffffffffffffffffffffffffff1690602001909291905050506108ce565b005b610274610967565b005b61027e610a9f565b6040518080602001828103825283818151815260200191508051906020019080838360005b838110156102be5780820151818401526020810190506102a3565b50505050905090810190601f1680156102eb5780820380516001836020036101000a031916815260200191505b509250505060405180910390f35b610301610b41565b6040518080602001828103825283818151815260200191508051906020019080838360005b83811015610341578082015181840152602081019050610326565b50505050905090810190601f16801561036e5780820380516001836020036101000a031916815260200191505b509250505060405180910390f35b6103f36004803603602081101561039257600080fd5b81019080803590602001906401000000008111156103af57600080fd5b8201836020820111156103c157600080fd5b803590602001918460018302840111640100000000831117156103e357600080fd5b9091929391929390505050610be3565b005b6103fd610d5c565b60405180827bffffffffffffffffffffffffffffffffffffffffffffffffffffffff1916815260200191505060405180910390f35b6104a96004803603602081101561044857600080fd5b810190808035906020019064010000000081111561046557600080fd5b82018360208201111561047757600080fd5b8035906020019184600183028401116401000000008311171561049957600080fd5b9091929391929390505050610d73565b005b6104e1600480360360408110156104c157600080fd5b810190808035906020019092919080359060200190929190505050610eec565b604051808273ffffffffffffffffffffffffffffffffffffffff16815260200191505060405180910390f35b6105596004803603604081101561052357600080fd5b8101908080359060200190929190803573ffffffffffffffffffffffffffffffffffffffff169060200190929190505050610f1d565b60405180821515815260200191505060405180910390f35b610579610f4e565b6040518082815260200191505060405180910390f35b6105da600480360360208110156105a557600080fd5b8101908080357bffffffffffffffffffffffffffffffffffffffffffffffffffffffff19169060200190929190505050610f55565b005b6105e4610fe7565b005b6105ee6111de565b6040518080602001828103825283818151815260200191508051906020019080838360005b8381101561062e578082015181840152602081019050610613565b50505050905090810190601f16801561065b5780820380516001836020036101000a031916815260200191505b509250505060405180910390f35b6106956004803603602081101561067f57600080fd5b8101908080359060200190929190505050611280565b6040518082815260200191505060405180910390f35b6106f7600480360360408110156106c157600080fd5b8101908080359060200190929190803573ffffffffffffffffffffffffffffffffffffffff1690602001909291905050506112a6565b005b61070161132f565b6040518082815260200191505060405180910390f35b61078e6004803603602081101561072d57600080fd5b810190808035906020019064010000000081111561074a57600080fd5b82018360208201111561075c57600080fd5b8035906020019184600183028401116401000000008311171561077e57600080fd5b9091929391929390505050611353565b005b6107d2600480360360208110156107a657600080fd5b81019080803573ffffffffffffffffffffffffffffffffffffffff1690602001909291905050506114cc565b005b6000600560009054906101000a900460e01b905090565b6000806000838152602001908152602001600020600201549050919050565b61083b7fb19546dff01e856fb3f010c267a7b1c60363cf8a4664e21cc89c26224620214e610836611763565b6108ce565b61084361176b565b565b61086b60008084815260200190815260200160002060020154610866611763565b610f1d565b6108c0576040517f08c379a000000000000000000000000000000000000000000000000000000000815260040180806020018281038252602f81526020018061252c602f913960400191505060405180910390fd5b6108ca8282611832565b5050565b6108d6611763565b73ffffffffffffffffffffffffffffffffffffffff168173ffffffffffffffffffffffffffffffffffffffff1614610959576040517f08c379a000000000000000000000000000000000000000000000000000000000815260040180806020018281038252602f8152602001806126b2602f913960400191505060405180910390fd5b61096382826118c5565b5050565b6109987fb19546dff01e856fb3f010c267a7b1c60363cf8a4664e21cc89c26224620214e610993611763565b610f1d565b6109ed576040517f08c379a000000000000000000000000000000000000000000000000000000000815260040180806020018281038252602281526020018061255b6022913960400191505060405180910390fd5b600073ffffffffffffffffffffffffffffffffffffffff16600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff161415610a95576040517f08c379a00000000000000000000000000000000000000000000000000000000081526004018080602001828103825260308152602001806124da6030913960400191505060405180910390fd5b610a9d61176b565b565b606060038054600181600116156101000203166002900480601f016020809104026020016040519081016040528092919081815260200182805460018160011615610100020316600290048015610b375780601f10610b0c57610100808354040283529160200191610b37565b820191906000526020600020905b815481529060010190602001808311610b1a57829003601f168201915b5050505050905090565b606060048054600181600116156101000203166002900480601f016020809104026020016040519081016040528092919081815260200182805460018160011615610100020316600290048015610bd95780601f10610bae57610100808354040283529160200191610bd9565b820191906000526020600020905b815481529060010190602001808311610bbc57829003601f168201915b5050505050905090565b610c147fb19546dff01e856fb3f010c267a7b1c60363cf8a4664e21cc89c26224620214e610c0f611763565b610f1d565b610c69576040517f08c379a000000000000000000000000000000000000000000000000000000000815260040180806020018281038252602281526020018061255b6022913960400191505060405180910390fd5b610cb682828080601f016020809104026020016040519081016040528093929190818152602001838380828437600081840152601f19601f82011690508083019250505050505050611958565b610d0b576040517f08c379a000000000000000000000000000000000000000000000000000000000815260040180806020018281038252602681526020018061260d6026913960400191505060405180910390fd5b610d5882828080601f016020809104026020016040519081016040528093929190818152602001838380828437600081840152601f19601f820116905080830192505050505050506119f5565b5050565b6000600160149054906101000a900460e01b905090565b610da47fb19546dff01e856fb3f010c267a7b1c60363cf8a4664e21cc89c26224620214e610d9f611763565b610f1d565b610df9576040517f08c379a000000000000000000000000000000000000000000000000000000000815260040180806020018281038252602281526020018061255b6022913960400191505060405180910390fd5b610e4682828080601f016020809104026020016040519081016040528093929190818152602001838380828437600081840152601f19601f82011690508083019250505050505050611958565b610e9b576040517f08c379a00000000000000000000000000000000000000000000000000000000081526004018080602001828103825260268152602001806126336026913960400191505060405180910390fd5b610ee882828080601f016020809104026020016040519081016040528093929190818152602001838380828437600081840152601f19601f82011690508083019250505050505050611c0f565b5050565b6000610f1582600080868152602001908152602001600020600001611e2990919063ffffffff16565b905092915050565b6000610f4682600080868152602001908152602001600020600001611e4390919063ffffffff16565b905092915050565b6000801b81565b610f867fb19546dff01e856fb3f010c267a7b1c60363cf8a4664e21cc89c26224620214e610f81611763565b610f1d565b610fdb576040517f08c379a000000000000000000000000000000000000000000000000000000000815260040180806020018281038252602281526020018061255b6022913960400191505060405180910390fd5b610fe481611e73565b50565b600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16611028611763565b73ffffffffffffffffffffffffffffffffffffffff1614611094576040517f08c379a000000000000000000000000000000000000000000000000000000000815260040180806020018281038252603081526020018061257d6030913960400191505060405180910390fd5b60006110c17fb19546dff01e856fb3f010c267a7b1c60363cf8a4664e21cc89c26224620214e6000610eec565b90506000600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1690506111147fb19546dff01e856fb3f010c267a7b1c60363cf8a4664e21cc89c26224620214e82611fa4565b61113e7fb19546dff01e856fb3f010c267a7b1c60363cf8a4664e21cc89c26224620214e836112a6565b6000600160006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff1602179055508073ffffffffffffffffffffffffffffffffffffffff168273ffffffffffffffffffffffffffffffffffffffff167fa179de4974935ad47df963bb937ec8783df4fbc79e2958603f84cae534556ecd60405160405180910390a35050565b606060028054600181600116156101000203166002900480601f0160208091040260200160405190810160405280929190818152602001828054600181600116156101000203166002900480156112765780601f1061124b57610100808354040283529160200191611276565b820191906000526020600020905b81548152906001019060200180831161125957829003601f168201915b5050505050905090565b600061129f600080848152602001908152602001600020600001611fb2565b9050919050565b6112cc600080848152602001908152602001600020600201546112c7611763565b610f1d565b611321576040517f08c379a00000000000000000000000000000000000000000000000000000000081526004018080602001828103825260308152602001806125dd6030913960400191505060405180910390fd5b61132b82826118c5565b5050565b7fb19546dff01e856fb3f010c267a7b1c60363cf8a4664e21cc89c26224620214e81565b6113847fb19546dff01e856fb3f010c267a7b1c60363cf8a4664e21cc89c26224620214e61137f611763565b610f1d565b6113d9576040517f08c379a000000000000000000000000000000000000000000000000000000000815260040180806020018281038252602281526020018061255b6022913960400191505060405180910390fd5b61142682828080601f016020809104026020016040519081016040528093929190818152602001838380828437600081840152601f19601f82011690508083019250505050505050611958565b61147b576040517f08c379a000000000000000000000000000000000000000000000000000000000815260040180806020018281038252602881526020018061268a6028913960400191505060405180910390fd5b6114c882828080601f016020809104026020016040519081016040528093929190818152602001838380828437600081840152601f19601f82011690508083019250505050505050611fc7565b5050565b6114fd7fb19546dff01e856fb3f010c267a7b1c60363cf8a4664e21cc89c26224620214e6114f8611763565b610f1d565b611552576040517f08c379a000000000000000000000000000000000000000000000000000000000815260040180806020018281038252602281526020018061255b6022913960400191505060405180910390fd5b600073ffffffffffffffffffffffffffffffffffffffff168173ffffffffffffffffffffffffffffffffffffffff1614156115d8576040517f08c379a00000000000000000000000000000000000000000000000000000000081526004018080602001828103825260308152602001806125ad6030913960400191505060405180910390fd5b60006116057fb19546dff01e856fb3f010c267a7b1c60363cf8a4664e21cc89c26224620214e6000610eec565b90508173ffffffffffffffffffffffffffffffffffffffff168173ffffffffffffffffffffffffffffffffffffffff16141561168c576040517f08c379a00000000000000000000000000000000000000000000000000000000081526004018080602001828103825260318152602001806126596031913960400191505060405180910390fd5b61169461176b565b81600160006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff1602179055508173ffffffffffffffffffffffffffffffffffffffff168173ffffffffffffffffffffffffffffffffffffffff167fd97997d860b456aa57404231a9a9b6a699900101f852b112071e5642fc15c9d560405160405180910390a35050565b600061175b836000018373ffffffffffffffffffffffffffffffffffffffff1660001b6121e1565b905092915050565b600033905090565b600073ffffffffffffffffffffffffffffffffffffffff16600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1614611830576000600160006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff1602179055507f796443f850505d852410fce306078cf77c1b11ac436c926d7e5237513efa2df760405160405180910390a15b565b6118598160008085815260200190815260200160002060000161173390919063ffffffff16565b156118c157611866611763565b73ffffffffffffffffffffffffffffffffffffffff168173ffffffffffffffffffffffffffffffffffffffff16837f2f8788117e7eff1d82e926ec794901d17c78024a50270940304540a733656f0d60405160405180910390a45b5050565b6118ec8160008085815260200190815260200160002060000161225190919063ffffffff16565b15611954576118f9611763565b73ffffffffffffffffffffffffffffffffffffffff168173ffffffffffffffffffffffffffffffffffffffff16837ff6391f5c32d9c69d2a47ea670b442974b53935d1edc7fd64eb21e047a839171b60405160405180910390a45b5050565b6000602182511480156119ee5750600260f81b8260008151811061197857fe5b602001015160f81c60f81b7effffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff191614806119ed5750600360f81b826000815181106119be57fe5b602001015160f81c60f81b7effffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff1916145b5b9050919050565b611a9960038054600181600116156101000203166002900480601f016020809104026020016040519081016040528092919081815260200182805460018160011615610100020316600290048015611a8e5780601f10611a6357610100808354040283529160200191611a8e565b820191906000526020600020905b815481529060010190602001808311611a7157829003601f168201915b505050505082612281565b15611c0c57600560009054906101000a900460e01b7bffffffffffffffffffffffffffffffffffffffffffffffffffffffff19167f950f942383e7d5e469f9efa063df3d5af93dc7a7108c2039418309840e2d6b0f600383604051808060200180602001838103835285818154600181600116156101000203166002900481526020019150805460018160011615610100020316600290048015611b7e5780601f10611b5357610100808354040283529160200191611b7e565b820191906000526020600020905b815481529060010190602001808311611b6157829003601f168201915b5050838103825284818151815260200191508051906020019080838360005b83811015611bb8578082015181840152602081019050611b9d565b50505050905090810190601f168015611be55780820380516001836020036101000a031916815260200191505b5094505050505060405180910390a28060039080519060200190611c0a92919061243c565b505b50565b611cb360048054600181600116156101000203166002900480601f016020809104026020016040519081016040528092919081815260200182805460018160011615610100020316600290048015611ca85780601f10611c7d57610100808354040283529160200191611ca8565b820191906000526020600020905b815481529060010190602001808311611c8b57829003601f168201915b505050505082612281565b15611e2657600560009054906101000a900460e01b7bffffffffffffffffffffffffffffffffffffffffffffffffffffffff19167faa96f2fda75fa7cf89d9d618a482d7e9345538c3c92aae6534a77f22b5b16b06600483604051808060200180602001838103835285818154600181600116156101000203166002900481526020019150805460018160011615610100020316600290048015611d985780601f10611d6d57610100808354040283529160200191611d98565b820191906000526020600020905b815481529060010190602001808311611d7b57829003601f168201915b5050838103825284818151815260200191508051906020019080838360005b83811015611dd2578082015181840152602081019050611db7565b50505050905090810190601f168015611dff5780820380516001836020036101000a031916815260200191505b5094505050505060405180910390a28060049080519060200190611e2492919061243c565b505b50565b6000611e38836000018361229d565b60001c905092915050565b6000611e6b836000018373ffffffffffffffffffffffffffffffffffffffff1660001b612320565b905092915050565b807bffffffffffffffffffffffffffffffffffffffffffffffffffffffff1916600160149054906101000a900460e01b7bffffffffffffffffffffffffffffffffffffffffffffffffffffffff191614611fa157600560009054906101000a900460e01b7bffffffffffffffffffffffffffffffffffffffffffffffffffffffff19167f4750a47067e046fac31480e0b4e2cae9612447cf7627188a1e6ca15a15f68dad600160149054906101000a900460e01b8360405180837bffffffffffffffffffffffffffffffffffffffffffffffffffffffff19168152602001827bffffffffffffffffffffffffffffffffffffffffffffffffffffffff191681526020019250505060405180910390a280600160146101000a81548163ffffffff021916908360e01c02179055505b50565b611fae8282611832565b5050565b6000611fc082600001612343565b9050919050565b61206b60028054600181600116156101000203166002900480601f0160208091040260200160405190810160405280929190818152602001828054600181600116156101000203166002900480156120605780601f1061203557610100808354040283529160200191612060565b820191906000526020600020905b81548152906001019060200180831161204357829003601f168201915b505050505082612281565b156121de57600560009054906101000a900460e01b7bffffffffffffffffffffffffffffffffffffffffffffffffffffffff19167f5c96fb34ed318f1d939bea5d00d59bca36271387847cbcfeb26662013ec937a66002836040518080602001806020018381038352858181546001816001161561010002031660029004815260200191508054600181600116156101000203166002900480156121505780601f1061212557610100808354040283529160200191612150565b820191906000526020600020905b81548152906001019060200180831161213357829003601f168201915b5050838103825284818151815260200191508051906020019080838360005b8381101561218a57808201518184015260208101905061216f565b50505050905090810190601f1680156121b75780820380516001836020036101000a031916815260200191505b5094505050505060405180910390a280600290805190602001906121dc92919061243c565b505b50565b60006121ed8383612320565b61224657826000018290806001815401808255809150506001900390600052602060002001600090919091909150558260000180549050836001016000848152602001908152602001600020819055506001905061224b565b600090505b92915050565b6000612279836000018373ffffffffffffffffffffffffffffffffffffffff1660001b612354565b905092915050565b6000818051906020012083805190602001201415905092915050565b6000818360000180549050116122fe576040517f08c379a000000000000000000000000000000000000000000000000000000000815260040180806020018281038252602281526020018061250a6022913960400191505060405180910390fd5b82600001828154811061230d57fe5b9060005260206000200154905092915050565b600080836001016000848152602001908152602001600020541415905092915050565b600081600001805490509050919050565b60008083600101600084815260200190815260200160002054905060008114612430576000600182039050600060018660000180549050039050600086600001828154811061239f57fe5b90600052602060002001549050808760000184815481106123bc57fe5b90600052602060002001819055506001830187600101600083815260200190815260200160002081905550866000018054806123f457fe5b60019003818190600052602060002001600090559055866001016000878152602001908152602001600020600090556001945050505050612436565b60009150505b92915050565b828054600181600116156101000203166002900490600052602060002090601f016020900481019282601f1061247d57805160ff19168380011785556124ab565b828001600101855582156124ab579182015b828111156124aa57825182559160200191906001019061248f565b5b5090506124b891906124bc565b5090565b5b808211156124d55760008160009055506001016124bd565b509056fe4f776e6572526f6c653a206f776e657273686970207472616e73666572206973206e6f7420696e2d70726f6772657373456e756d657261626c655365743a20696e646578206f7574206f6620626f756e6473416363657373436f6e74726f6c3a2073656e646572206d75737420626520616e2061646d696e20746f206772616e744f776e6572526f6c653a2063616c6c6572206973206e6f7420746865206f776e65724f776e6572526f6c653a2063616c6c6572206973206e6f7420746865206e6577206f776e65722063616e6469646174654f776e6572526f6c653a206e65774f776e657243616e64696461746520697320746865207a65726f2061646472657373416363657373436f6e74726f6c3a2073656e646572206d75737420626520616e2061646d696e20746f207265766f6b6556415350436f6e74726163743a206e65774d6573736167654b657920697320696e76616c696456415350436f6e74726163743a206e65775369676e696e674b657920697320696e76616c69644f776e6572526f6c653a206e65774f776e657243616e646964617465206973207468652063757272656e74206f776e657256415350436f6e74726163743a206e65775472616e73706f72744b657920697320696e76616c6964416363657373436f6e74726f6c3a2063616e206f6e6c792072656e6f756e636520726f6c657320666f722073656c66a2646970667358221220361a29ff2e6ff94d2f65b2cae7a45fc8379e2da395f87e30f6de9e4ddead61c164736f6c634300060c003356415350436f6e74726163743a207472616e73706f72744b657920697320696e76616c696456415350436f6e74726163743a207369676e696e674b657920697320696e76616c696456415350436f6e74726163743a206d6573736167654b657920697320696e76616c69644f776e6572526f6c653a206f776e657220697320746865207a65726f2061646472657373";

        
        public VASPContract(
            Address address, 
            IWeb3 web3)
            
            : base(address, web3)
        {
            
        }
        
        public VASPContract(
            Address fakeAddress,
            Address realAddress,
            IWeb3 web3)
            
            : base(fakeAddress, realAddress, web3)
        {
            
        }


        public Task SetChannelsAsync(
            Address owner,
            Channels channels)
        {
            return SetPropertyAsync(owner, "setChannels", (byte[]) channels);
        }
        
        public Task SetMessageKeyAsync(
            Address owner,
            MessageKey messageKey)
        {
            return SetPropertyAsync(owner, "setMessageKey", (byte[]) messageKey);
        }
        
        public Task SetSigningKeyAsync(
            Address owner,
            SigningKey signingKey)
        {
            return SetPropertyAsync(owner, "setSigningKey", (byte[]) signingKey);
        }
        
        public Task SetTransportKeyAsync(
            Address owner,
            TransportKey transportKey)
        {
            return SetPropertyAsync(owner, "setTransportKey", (byte[]) transportKey);
        }

        private async Task SetPropertyAsync(
            Address owner,
            string functionName,
            object value)
        {
            var contract = Web3.Eth.GetContract(ABI, RealAddress);
            var function = contract.GetFunction(functionName);
            var functionInput = new[] { value };

            var gas = await function.EstimateGasAsync
            (
                @from: owner,
                gas: new HexBigInteger(1000000),
                value: new HexBigInteger(0),
                functionInput
            );
            
            await function.SendTransactionAndWaitForReceiptAsync
            (
                @from: owner,
                gas: gas,
                value: new HexBigInteger(0),
                receiptRequestCancellationToken: null,
                functionInput: functionInput
            );
        }
    }
}